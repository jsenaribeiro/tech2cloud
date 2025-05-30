namespace Ambev.DeveloperEvaluation.Common.Broker;

public interface IRedisPublisher
{
   Task PublishAsync(string channel, string message);
}