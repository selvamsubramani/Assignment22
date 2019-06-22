using System.ServiceProcess;

namespace FSE.Assignment22.Service.WindowService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WeatherService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
