using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjadaCompany.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EjadaCompany.Pages.EmployeeList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; // Create Object of DbContext
        public IndexModel(ApplicationDbContext db) // Constructor that take ApplicationDbContext Object From Dependency Injection
        {
            _db = db;
        }

        public IEnumerable<Employee> Employees { get; set; } // Employees is a list of IEnumerable that will have all employees from Database

        public async Task OnGet() // Any Handler Using await Must Have A Return Type As async Task
        {
            // It Expected to See all Employees List from Database, so get them and put them in list
            Employees = await _db.Employee.ToListAsync(); //Async is used to be able to run multiple thread on Parrallel        
        }

        // This Handle is a Post Type as Form in Index.cshtml have Post Method, Also We will Post to Database
        // async Task : as this Handler use await Keyword to handle Multiple Thread Access
        // Task of King IActionResult : As return will direct me to Page
        // This Handler Of Name Delete ... As this name is passed as handler name to Delete Button
        // This Handler Take ID as argument, as it must be known which employee will be working on
        public async Task<IActionResult> OnPostDelete(int id) 
        {
            var employee = await _db.Employee.FindAsync(id); // Find Employee with given ID
            if (employee == null)
            {
                return NotFound();
            }
            _db.Employee.Remove(employee); // If found the intended employee .. then remove it from Database
            await _db.SaveChangesAsync(); // Changes will not be saved to database without this step

            return RedirectToPage("Index"); //Go back to Index Page ... thats why we use IActionResult Type
        }


    }
}
