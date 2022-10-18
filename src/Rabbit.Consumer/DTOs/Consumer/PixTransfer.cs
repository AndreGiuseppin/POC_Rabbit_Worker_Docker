namespace Rabbit.Consumer.DTOs.Consumer
{
    public record PixTransfer(string BranchFrom, string AccountFrom, string BranchTo, string AccountTo, string Value);
}
