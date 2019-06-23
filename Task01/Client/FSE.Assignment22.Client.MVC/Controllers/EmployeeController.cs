using FSE.Assignment22.Client.MVC.EmployeeServiceReference;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FSE.Assignment22.Client.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Load()
        {
            using (var client = new EmployeeServiceClient())
            {
                var employees =
                    client.RetreiveEmployees().Select(emp =>
                    new Models.Employee
                    {
                        Id = emp.EmployeeID,
                        Name = emp.EmployeeName,
                        Designation = emp.Designation,
                        Department = emp.DepartmentName
                    }).ToList();
                return View("Index", employees);
            }
        }
        public ActionResult GetEmployeesById(string employeeid)
        {
            var id = Convert.ToInt32(employeeid);
            using (var client = new EmployeeServiceClient())
            {
                var employees =
                    client.RetreiveEmployeeByID(id).Select(emp =>
                    new Models.Employee
                    {
                        Id = emp.EmployeeID,
                        Name = emp.EmployeeName,
                        Designation = emp.Designation,
                        Department = emp.DepartmentName
                    }).ToList();
                return View("Index", employees);
            }
        }
        public ActionResult Create()
        {
            return View(new Models.Employee());
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            using (var client = new EmployeeServiceClient())
            {
                client.AddEmployee(
                    new Employee
                    {
                        EmployeeName = collection.Get("Name"),
                        Designation = collection.Get("Designation"),
                        DepartmentName = collection.Get("Department")
                    });
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            using (var client = new EmployeeServiceClient())
            {
                var employee = client.RetreiveEmployeeByID(id).FirstOrDefault();
                return View(employee);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            using (var client = new EmployeeServiceClient())
            {
                client.UpdateEmployee(
                    new Employee
                    {
                        EmployeeID = id,
                        EmployeeName = collection.Get("EmployeeName"),
                        Designation = collection.Get("Designation"),
                        DepartmentName = collection.Get("DepartmentName")
                    });
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (var client = new EmployeeServiceClient())
            {
                var status = client.DeleteEmployee(id);
                ViewBag.Title = status ? "Successfully Deleted" : "Failed to Delete";
                return View();
            }
        }
    }
}