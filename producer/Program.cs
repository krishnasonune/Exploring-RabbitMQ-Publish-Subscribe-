using commonFunctionality.Repository;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

var _factory = new ConnectionFactory{HostName="localhost"};
var _connection = _factory.CreateConnection();
var _channel = _connection.CreateModel();

QueuesAndChannel.DeclareQueueAndChannel(_channel);

var comments = await CommentsAPI.GetComments();
for (int i = 0; i <= 4; i++)
{
    var jsonObj = JsonConvert.SerializeObject(comments[i]);
    var message = Encoding.UTF8.GetBytes(jsonObj);
    _channel.BasicPublish(
        exchange: "CommentsExchange",
        routingKey: "comments",
        basicProperties: null,
        body: message
    );
}
System.Console.WriteLine("message is sent");
Console.ReadKey();