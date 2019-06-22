using System.Runtime.Serialization;

namespace FSE.Assignment22.Service.Core
{
    [DataContract]
    public class Employee
    {
        [DataMember(Name = "Employee ID")]
        public int Id { get; set; }
        [DataMember(Name = "Employee Name")]
        public string Name { get; set; }
        [DataMember(Name = "Designation")]
        public string Designation { get; set; }
        [DataMember(Name = "Department Name")]
        public string Department { get; set; }
    }
}
