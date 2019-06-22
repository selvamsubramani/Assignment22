using FSE.Assignment22.Service.Core;
using System.ServiceModel;

namespace FSE.Assignment22.Service.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WeatherService));
            host.Open();
            System.Console.WriteLine("Service is started");
            System.Console.Read();
        }
    }
}
