using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelDemo.Models;
using ModelDemo.ViewModels;

namespace ModelDemo.Controllers
{
   
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public ViewResult Index()
        {
            // retrieve all the employees
            var model = _employeeRepository.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }


        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        public ViewResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            //if (ModelState.IsValid)
            //{
            //    Employee newEmployee = _employeeRepository.Add(employee);
            //    return RedirectToAction("Details", new { id = newEmployee.Id });
            //}
            //return View();

            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
            }

            return View();
        }
    }
}