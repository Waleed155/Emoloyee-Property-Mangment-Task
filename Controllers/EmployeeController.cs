 using Emoloyee_Property_Mangment_Task.Dto.EmployeeDto;
using Emoloyee_Property_Mangment_Task.ViewModel;

using Emoloyee_Property_Mangment_Task.Services;
using Emoloyee_Property_Mangment_Task.Services.PropertyService;
using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;

using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emoloyee_Property_Mangment_Task.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeService _employeeService;
        IPropertyService _propertyService;
        public EmployeeController(IEmployeeService employeeService,
            IPropertyService propertyService) {
            _employeeService = employeeService;
               _propertyService = propertyService;
        }
        public ActionResult Index()
        {
            ViewBag.properties = _propertyService.GetAll().ProjectToType<PropertyViewModel>().ToList();
            var employeesDto = _employeeService.GetAll().ToList();

            TypeAdapterConfig<EmployeeDto, EmployeeViewModel>.
              NewConfig().
               Map(dst => dst.EmployeeProperties,
               src => src.EmployeeProperties
               .Adapt<HashSet<EmployeePropertyViewModel>>());
            var employeesViewModel = employeesDto.Adapt<HashSet<EmployeeViewModel>>();
            return View(employeesViewModel);
        }
        public ActionResult Create() 
        {
            ViewBag.isEdit = false;
            var empFormDto = _employeeService.
                GetFormAddEmployee();
      TypeAdapterConfig<EmployeeAddDto, EmployeeFormViewModel>.
                NewConfig().
                 Map(dst => dst.PropertiesViewModel,
                 src =>src.
                 Properties.Adapt<HashSet<PropertyAddViewModel>>());

       var  empFormViewModel  = empFormDto.Adapt<EmployeeFormViewModel>();
            return View("FormAddEmployee",empFormViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(EmployeeFormViewModel employeeFormViewModel)
        {
            ViewBag.isEdit = false;
            try
            {
                if (ModelState.IsValid)
                {
                    TypeAdapterConfig<EmployeeFormViewModel, EmployeeAddDto>.
                    NewConfig().
                     Map(dst => dst.Properties,
                     src => src.
                     PropertiesViewModel.
                     Adapt<HashSet<PropertyAddDto>>());
                    var employeeAddDto = employeeFormViewModel.
                        Adapt<EmployeeAddDto>();
                    if (await _employeeService.Add(employeeAddDto))
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                        return View("FormAddEmployee");
                }
                else
                {
                    return View("FormAddEmployee", employeeFormViewModel);
                }
            }
            catch
            {
                return View("FormAddEmployee", employeeFormViewModel);
            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.isEdit = true;

            var employeeAddDto =_employeeService.GetById(id);
            TypeAdapterConfig<EmployeeAddDto, EmployeeFormViewModel>.
                NewConfig().
                 Map(dst => dst.PropertiesViewModel,
                 src => src.
                 Properties.Adapt<HashSet<PropertyAddViewModel>>());
            var empFormViewModel = employeeAddDto.Adapt<EmployeeFormViewModel>();
            return View("FormAddEmployee",empFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(EmployeeFormViewModel employeeFormViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TypeAdapterConfig<EmployeeFormViewModel, EmployeeAddDto>.
                        NewConfig().
                        Map(dst => dst.Properties, src => src.PropertiesViewModel.Adapt<HashSet<PropertyAddDto>>());
                    var employeeAddDto = employeeFormViewModel.Adapt<EmployeeAddDto>();
                    if (await _employeeService.Edit(employeeAddDto))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View("FormAddEmployee", employeeFormViewModel);
                    }
                }
                else
                {
                    return View("FormAddEmployee", employeeFormViewModel);
                }
            }
            catch
            {
                             return View("FormAddEmployee", employeeFormViewModel);

            }
        }

        
        [HttpGet]
        public async Task <ActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));

            }
        }
    }
}
