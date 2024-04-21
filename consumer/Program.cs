using commonFunctionality.Repository;
using commonFunctionality.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var _factory = new ConnectionFactory(){
    HostName="localhost"
};

var _connection = _factory.CreateConnection();
var _channel = _connection.CreateModel();

QueuesAndChannel.DeclareQueueAndChannel(_channel);

var consumer = new EventingBasicConsumer(_channel);

consumer.Received += (model, eve) => { 
    var Message = eve.Body.ToArray();
    var decodedMessage = JsonConvert.DeserializeObject<Comments>(Encoding.UTF8.GetString(Message));

    System.Console.WriteLine($"Id : {decodedMessage.id}, Name : {decodedMessage.name}");
    
    _channel.BasicAck(deliveryTag: eve.DeliveryTag, multiple: false);
};

_channel.BasicConsume(queue:"comments",
                    autoAck:true,
                    consumer: consumer);

Console.ReadKey();