using System.ServiceModel;
using System.ServiceProcess;

namespace FSE.Assignment22.Service.WindowService
{
    public partial class WeatherService : ServiceBase
    {
        ServiceHost host;
        public WeatherService()
        {
            InitializeComponent();
            host = new ServiceHost(typeof(Core.WeatherService));
        }

        protected override void OnStart(string[] args)
        {
            if (host != null)
                host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
                host.Close();
        }
    }
}
