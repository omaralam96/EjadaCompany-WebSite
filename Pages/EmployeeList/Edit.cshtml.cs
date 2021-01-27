using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjadaCompany.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjadaCompany.Pages.EmployeeList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Create Object of DbContext
        public EditModel(ApplicationDbContext db) // Constructor that take ApplicationDbContext Object From Dependency Injection
        {
            _db = db;
        }

        [BindProperty] // This property enable as to avoid making new object of Employee and pass it to Post, Instead it will bind to Orignal Employee defined below 
        public Employee employee { get; set; } // Only One Employee is going to be Edited at one time
        public async Task OnGet(int id) // async: for await keyword
        {
            // It is Expected to Get the information for the employee to be edited from Database
            employee = await _db.Employee.FindAsync(id);

        }

        // This Handle is a Post Type as Form in Index.cshtml have Post Method, Also We will Post to Database
        // async Task : as this Handler use await Keyword to handle Multiple Thread Access
        // Task of King IActionResult : As return will direct me to Page
        // This Handler Take ID as argument, as it must be known which employee will be working on
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) // Add BackEnd Validation For Section that Can't be NULL
            {
                var EmployeeFromDb = await _db.Employee.FindAsync(employee.Id); // Get The Intended Employee
                // Update It's Information
                EmployeeFromDb.Name = employee.Name;
                EmployeeFromDb.Team = employee.Team;
                EmployeeFromDb.Position = employee.Position;
                EmployeeFromDb.Branch = employee.Branch;
                EmployeeFromDb.Email = employee.Email;
                EmployeeFromDb.Telphone = employee.Telphone;
                EmployeeFromDb.Address = employee.Address;

                await _db.SaveChangesAsync(); //Save to Database

                return RedirectToPage("Index"); // Return to Index Page
            }
            return RedirectToPage(); // Stay in Same Page if the validation checks Fail
        }
    }
}
