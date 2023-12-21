using Confluent.Kafka;
using Newtonsoft.Json;


var config = new ProducerConfig { BootstrapServers = "0.0.0.0:9092" };
using var producer = new ProducerBuilder<Null, string>(config).Build();
try
{
	string? name;
	while ((name = Console.ReadLine()) != null)
	{
		Random rnd = new Random();
        var response = await producer.ProduceAsync("permissions-topic",
        new Message<Null, string> { Value = JsonConvert.SerializeObject(
		new User(name, rnd.Next()))});
		Console.WriteLine(response.Value);
    }	

}
catch (Exception ex)
{

	throw;
}

public record User (string name, int Guid);

