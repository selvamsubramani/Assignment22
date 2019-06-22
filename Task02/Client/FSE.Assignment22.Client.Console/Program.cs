using FSE.Assignment22.Client.Console.WeatherServiceReference;
using System;

namespace FSE.Assignment22.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Select Operations to Perform");
            System.Console.WriteLine("1. Celsius to Ferenheit");
            System.Console.WriteLine("2. Ferenheit to Celsius");
            var operation = System.Console.ReadLine();
            int op = -1;
            Int32.TryParse(operation, out op);
            switch(op)
            {
                case 1:
                    CtoF();
                    break;
                case 2:
                    FtoC();
                    break;
                default:
                    System.Console.WriteLine("Invalid Operation Selecetd");
                    break;
            }
            System.Console.Read();
        }

        static void CtoF()
        {
            using (var client = new WeatherServiceClient())
            {
                var input = GetInput();
                var output = client.CelciusToFarenheit(input);
                System.Console.WriteLine($"Celcius: {input} - Farenheit: {output}");
            }
        }
        static void FtoC()
        {
            using (var client = new WeatherServiceClient())
            {
                var input = GetInput();
                var output = client.FarenheitToCelcius(input);
                System.Console.WriteLine($"Farenheit: {input} - Celcius: {output}");
            }
        }
        static double GetInput()
        {
            System.Console.Write("Provide value to convert");
            var input = System.Console.ReadLine();
            double temperature = 0.0;
            Double.TryParse(input, out temperature);
            return temperature;
        }
    }
}
