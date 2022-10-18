using MassTransit;
using Rabbit.Consumer.Consumer;
using Rabbit.Producer.Configurations;
using Rabbit.Producer.Interfaces.Producer;
using Rabbit.Producer.Producer;

namespace POC_Rabbit_Worker_Docker.Extensions
{
    public static class ServiceConfigExtensions
    {
        public static void SetupDependencyInjection(
            this IServiceCollection services)
        {
            services.AddScoped<IPixProducer, PixProducer>();
        }

        public static void AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<PixConsumer>();

                var rabbitConfiguration = configuration.GetSection("ConnectionStrings:RabbitMQCluster").Get<RabbitConfiguration>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(
                         new Uri(rabbitConfiguration.Cluster),
                        h =>
                        {
                            h.Username(rabbitConfiguration.Username);
                            h.Password(rabbitConfiguration.Password);
                            h.UseCluster(x =>
                            {
                                foreach (var node in rabbitConfiguration.Hosts)
                                    x.Node(node);
                            });
                        });

                    cfg.UseMessageRetry(r => r.Intervals(rabbitConfiguration.Retries));

                    cfg.UseKillSwitch(options => options
                        .SetActivationThreshold(10)
                        .SetTripThreshold(0.15)
                        .SetRestartTimeout(m: 1));

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
