namespace Rabbit.Producer.Configurations
{
    public class RabbitConfiguration
    {
        public string Cluster { get; set; }
        public string[] Hosts { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int[] Retries { get; set; }
    }
}
