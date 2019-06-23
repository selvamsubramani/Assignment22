using System.ComponentModel.DataAnnotations;

namespace FSE.Assignment22.Client.MVC.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Department Name")]
        public string Department { get; set; }
    }
}