using EjadaCompany.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjadaCompany.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db; // Create Object of DbContext
        public EmployeeController(ApplicationDbContext db) // Constructor that take ApplicationDbContext Object From Dependency Injection
        {
            _db = db;
        }

        // The Purpose of The Following is Displaying Table And Messeges of all option related to Index Page with Nicer Format

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Employee.ToListAsync() }); //This is used to display table of Employee in Nicer Format
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var EmployeeFromDb = await _db.Employee.FirstOrDefaultAsync(u => u.Id == id);
            if (EmployeeFromDb == null) // In Case of Not Found the intended Employee , Return Error Messege with Sweet Alert
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Employee.Remove(EmployeeFromDb); // Remove The Intended Employee
            await _db.SaveChangesAsync();        // Save Changes to Database
            return Json(new { success = true, message = "Delete successful" }); // Display A Nice Format Messege
        }
    }
}
