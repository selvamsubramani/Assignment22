using FSE.Assignment22.Service.Core.Utility;
using System.Collections.Generic;

namespace FSE.Assignment22.Service.Core
{
    public class EmployeeService : IEmployeeService
    {
        public void AddEmployee(Employee employee)
        {
            DataConnector.Instance.AddEmployee(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            return DataConnector.Instance.DeleteEmployee(employeeId);
        }

        public List<Employee> RetreiveEmployeeByID(int employeeId)
        {
            return DataConnector.Instance.GetEmployees(employeeId);
        }

        public List<Employee> RetreiveEmployees()
        {
            return DataConnector.Instance.GetEmployees();
        }

        public void UpdateEmployee(Employee employee)
        {
            DataConnector.Instance.UpdateEmployee(employee);
        }
    }
}