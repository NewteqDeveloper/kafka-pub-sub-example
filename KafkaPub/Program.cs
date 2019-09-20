using System;
using System.Threading;
using Confluent.Kafka;

namespace KafkaPub
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            Action<DeliveryReport<Null, string>> handler = r => Console.WriteLine(
                !r.Error.IsError
                    ? $"Message delivered :) to {r.TopicPartitionOffsetError}"
                    : $"Message delivery failed :( awwww REASON? -- {r.Error.Reason}");

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                for (var i = 0; i < 100; i++)
                {
                    producer.Produce("sample-topic", new Message<Null, string>() { Value = $"Publisher message - {i}" }, handler);
                    Thread.Sleep(1000);
                }

                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
