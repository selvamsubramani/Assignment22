using FSE.Assignment22.Service.Core;
using System;
using System.ServiceModel;

namespace FSE.Assignment22.Service.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EmployeeService));
            host.Open();

            Console.WriteLine($"Service is Started {host.Description.Endpoints[0].Address}");
            Console.Read();
        }
    }
}
