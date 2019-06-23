using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FSE.Assignment22.Service.Core.Utility
{
    public class DataConnector
    {
        private string connectionstring;
        private DataConnector()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["Assignment22"].ConnectionString;
        }
        private static readonly Lazy<DataConnector> lazy = new Lazy<DataConnector>(() => new DataConnector());
        public static DataConnector Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public DataTable ExecuteTable(string procedurename, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            using (var connection = new SqlConnection(connectionstring))
            {
                using (var command = new SqlCommand(procedurename, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }
        public int ExecuteReader(string procedurename, params SqlParameter[] parameters)
        {
            DataTable table = new DataTable();
            using (var connection = new SqlConnection(connectionstring))
            {
                using (var command = new SqlCommand(procedurename, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result;
                }
            }
        }
        public List<Employee> GetEmployees(int? id = null)
        {
            var storedprocedurename = "GetEmployees";
            var parameters = new List<SqlParameter>();
            if (id.HasValue)
            {
                storedprocedurename = "GetEmployeeByID";
                parameters.Add(new SqlParameter("Id", id.Value));
            }
            using (var table = ExecuteTable(storedprocedurename, parameters.ToArray()))
            {
                return table.AsEnumerable().Select(row =>
                new Employee
                {
                    Id = row.Field<int>("Id"),
                    Name = row.Field<string>("Name"),
                    Designation = row.Field<string>("Designation"),
                    Department = row.Field<string>("Department")
                }).ToList();
            }
        }
        public void AddEmployee(Employee employee)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Name", employee.Name));
            parameters.Add(new SqlParameter("Designation", employee.Designation));
            parameters.Add(new SqlParameter("Department", employee.Department));
            ExecuteReader("AddEmployee", parameters.ToArray());
        }
        public bool DeleteEmployee(int id)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", id));
            ExecuteReader("DeleteEmployee", parameters.ToArray());
            return true;
        }
        public void UpdateEmployee(Employee employee)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Id", employee.Id));
            parameters.Add(new SqlParameter("Name", employee.Name));
            parameters.Add(new SqlParameter("Designation", employee.Designation));
            parameters.Add(new SqlParameter("Department", employee.Department));
            ExecuteReader("UpdateEmployee", parameters.ToArray());
        }
    }
}