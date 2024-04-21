using RabbitMQ.Client;

namespace commonFunctionality.Repository;
public static class QueuesAndChannel
{
    public static void DeclareQueueAndChannel(IModel channel)
    {
        channel.ExchangeDeclare("CommentsExchangeDirect", type: ExchangeType.Direct);
        var queue = "comments";

        channel.QueueBind(queue: queue, exchange: "CommentsExchange", routingKey: "comments");

        channel.QueueDeclare(
            queue: queue,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );
    }
}
