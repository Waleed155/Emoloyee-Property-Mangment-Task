using Microsoft.EntityFrameworkCore;
using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.Repository;
using Emoloyee_Property_Mangment_Task.Services.PropertyService;
using Emoloyee_Property_Mangment_Task.Services;
using Emoloyee_Property_Mangment_Task.Dto.EmployeeDto;
using Emoloyee_Property_Mangment_Task.ViewModel;
using Mapster;
namespace Emoloyee_Property_Mangment_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.AddControllersWithViews();

            #region dependency injection
            builder.
                Services.
                 AddScoped<DbContext,Models.AppContext>();
            builder.
                Services.
                AddDbContext<Models.AppContext>(op=>op.
                UseSqlServer(builder.
                Configuration.
                GetConnectionString("Def")).
                EnableSensitiveDataLogging().
                EnableDetailedErrors());
            builder.
                Services.
                AddScoped(typeof(IRepository<>),typeof(Repository.Repository<>));
            
          
            builder.
                Services.
                AddScoped<IEmpRepository, EmpRepository>();
            builder.
                Services.
                AddScoped<IEmployeePropertyRepository, EmployeePropertyRepository>();
            builder.
                Services.
                AddScoped<IPropertyService,PropertyService>();
            builder.
                Services.
                AddScoped<IEmployeeService, EmployeeService>();

            
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
