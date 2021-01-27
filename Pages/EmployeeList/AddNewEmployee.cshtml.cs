using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjadaCompany.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjadaCompany.Pages.EmployeeList
{
    public class AddNewEmployeeModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Create Object of DbContext
        public AddNewEmployeeModel(ApplicationDbContext db) // Constructor that take ApplicationDbContext Object From Dependency Injection
        {
            _db = db;
        }

        [BindProperty] // This property enable as to avoid making new object of Employee and pass it to Post, Instead it will bind to Orignal Employee defined below 
        public Employee Employee { get; set; } // Only One Employee is going to be added at one time
        public void OnGet()
        {
            // I Am Not Expecting any data from database to be apeared so this handler is Empty
        }

        // This Handle is a Post Type as Form in Index.cshtml have Post Method, Also We will Post to Database
        // async Task : as this Handler use await Keyword to handle Multiple Thread Access
        // Task of King IActionResult : As return will direct me to Page
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) // Make BackEnd Validation, Some Sections Have to be inserted
            {
                await _db.Employee.AddAsync(Employee);  // Add Employee object
                await _db.SaveChangesAsync();           // Save Changes to Database
                return RedirectToPage("Index");         // Go back to Index Page
            }
            else
            {
                return Page();                          // Do Nothing, Just Refresh the Page
            }
        }
    }
}
