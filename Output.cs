using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializerNamespace
{
    public enum serializationType
    {
        Csv,
        Json,
        Deserialization
    }

    internal class Output
    {
        private readonly CsvSerializer serializer;
        private readonly int iterations;
        private readonly F f;

        public Output(F _f, int _iterations, CsvSerializer _serializer)
        {
            this.serializer = _serializer;
            iterations = _iterations;
            f = _f;
        }

        public void consoleOutput(serializationType _sType) 
        {
            string outputString = "";
            long serializationTime;
            F deserializedObject;

            if (_sType == serializationType.Deserialization) 
            {
                outputString = serializer.Serialize(f);
            }

            serializationTime = ActionTimer.CheckTime(() =>
            {
                for (int i = 0; i < iterations; i++)
                {
                    switch(_sType)
                    {
                        case serializationType.Csv:
                            if (serializer is not null)
                                outputString = serializer.Serialize(f);
                            else
                                outputString = "";
                            break;
                        case serializationType.Json:
                            outputString = JsonConvert.SerializeObject(f);
                            break;
                        case serializationType.Deserialization:
                            deserializedObject = F.DeserializeFromCsv(outputString);
                            break;
                    }                        
                }
            });

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            switch (_sType)
            {
                case serializationType.Csv:
                    Console.WriteLine($"Сериализация в CSV: {outputString}");
                    Console.WriteLine($"Время сериализации для {iterations} итераций: {serializationTime} миллисекунд");
                    break;
                case serializationType.Json:                    
                    Console.WriteLine($"Сериализация в JSON: {outputString}");
                    Console.WriteLine($"Время сериализации для {iterations} итераций: {serializationTime} миллисекунд");
                    break;
                case serializationType.Deserialization:
                    Console.WriteLine($"Время десериализации для {iterations} итераций: {serializationTime} миллисекунд");
                    break;
            }
            stopwatch.Stop();
            Console.WriteLine($"Время на вывод в консоль: {stopwatch.ElapsedMilliseconds} миллисекунд");
        }
    }
}
