using System;
using System.ServiceModel;

namespace FSE.Assignment22.Service.Core
{
    [ServiceContract]
    public interface IWeatherService
    {
        [OperationContract]
        Double CelciusToFarenheit(double temp);

        [OperationContract]
        Double FarenheitToCelcius(double temp);
    }
}