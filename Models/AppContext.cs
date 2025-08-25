using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Models
{
    public class AppContext:DbContext
    {
        public AppContext( DbContextOptions<AppContext> options):base(options )
        {

        }
        DbSet<Employee> Employees { get; set; }
        DbSet<Property> properties { get; set; }
        DbSet<EmployeeProperty> EmployeeProperties { get; set; }



    }
}
