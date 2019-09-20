using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Confluent.Kafka;

namespace KafkaSub
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Dictionary<string, string>
            {
                {"group.id", "sample-consumers"},
                {"bootstrap.servers", "localhost:9092"},
                {"enable.auto.commit", "false"}
            };
            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("sample-topic");

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = consumer.Consume(cts.Token);
                            Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occured: {e.Error.Reason}");
                        }
                    }
                }
                catch(Exception)
                {
                    consumer.Close();
                }
            }
        }
    }
}
