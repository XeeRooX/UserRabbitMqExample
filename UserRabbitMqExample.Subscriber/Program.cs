using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Xml;

var host = Environment.GetEnvironmentVariable("SubscriberHost") ?? "127.0.0.1";
var factory = new ConnectionFactory() { HostName = host };

var connection = factory.CreateConnection();
using var chanel = connection.CreateModel();
chanel.QueueDeclare("user", exclusive: false);

var consumer = new EventingBasicConsumer(chanel);
consumer.Received += (model, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    var obj = JsonSerializer.Deserialize<JsonDeserializaResult>(message, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true})!;

    var msgResult = obj.Msg;
    var bodyResult = JsonSerializer.Serialize(obj.Body, new JsonSerializerOptions() { WriteIndented = true });

    Console.WriteLine($"Сообщение {msgResult}");
    Console.WriteLine($"Объект: {bodyResult}");
    Console.WriteLine();
};

chanel.BasicConsume(queue: "user", autoAck: true, consumer: consumer);
Console.WriteLine("Ожидание сообщений...\n");

Thread.Sleep(Timeout.Infinite);


class JsonDeserializaResult
{
    public string? Msg { get; set; }
    public object? Body { get; set; }
}