using System.Collections.Generic;
using System.ServiceModel;

namespace FSE.Assignment22.Service.Core
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        void AddEmployee(Employee employee);
        [OperationContract]
        List<Employee> RetreiveEmployees();
        [OperationContract]
        List<Employee> RetreiveEmployeeByID(int employeeId);
        [OperationContract]
        void UpdateEmployee(Employee employee);
        [OperationContract]
        bool DeleteEmployee(int employeeId);
    }
}
