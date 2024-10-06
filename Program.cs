using Newtonsoft.Json;
using SerializerNamespace;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        const int iterations = 100000;

        var f = F.Get();        
        var csvSerializer = new CsvSerializer();
        
        Output obj = new Output(f, iterations, csvSerializer);        
        obj.consoleOutput(serializationType.Csv);
        obj.consoleOutput(serializationType.Json);
        obj.consoleOutput(serializationType.Deserialization);

        Console.ReadLine();
    }
    
}