using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Ambev.DeveloperEvaluation.Common.Broker;

public class RedisPublisher : IRedisPublisher
{
   private readonly IConnectionMultiplexer _redis;

   public RedisPublisher(IConnectionMultiplexer redis) => _redis = redis;

   public async Task PublishAsync(string channel, string message)
   {
      var originalColor = Console.ForegroundColor;

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine($"[REDIS] Channel: {channel}, Message: {message}");
      Console.ForegroundColor = originalColor;

      await _redis.GetSubscriber().PublishAsync(RedisChannel.Literal(channel), message);
   }
}
