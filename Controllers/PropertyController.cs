using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emoloyee_Property_Mangment_Task.Services;
using Emoloyee_Property_Mangment_Task.Services.PropertyService;
using Mapster;
using Emoloyee_Property_Mangment_Task.ViewModel;
using Emoloyee_Property_Mangment_Task.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Controllers
{
    public class PropertyController : Controller
    {
        IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
        _propertyService = propertyService;
        }
        public ActionResult Index()
        {
            var propertiesDto = _propertyService.GetAll().AsNoTracking() .ToList();
            var propertiesViewModel=propertiesDto.Adapt<List<PropertyViewModel>>();
            return View(propertiesViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.isEdit = false;
            ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(PropertyType)));
            return View("Create",new PropertyViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task< ActionResult> Create(PropertyViewModel propertyViewModel)
        {
            ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(PropertyType)));
            ViewBag.isEdit=false;
                
            try
            {
                if (ModelState.IsValid)
                {
                    var propertyDto = propertyViewModel.Adapt<PropertyDto>();
                    if (await _propertyService.Add(propertyDto))
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        return View(propertyViewModel);
                    }

                }
                else
                {
                    return View(propertyViewModel);
                }

            }
            catch
            {
                throw new Exception("error in db");

            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(PropertyType)));

            ViewBag.IsEdit = true;
            var propertyViewModel = _propertyService.GetById(id).Adapt<PropertyViewModel>();  

            return View("Create",propertyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PropertyViewModel propertyViewModel)
        {
            ViewBag.TypeList = new SelectList(Enum.GetValues(typeof(PropertyType)));
            ViewBag.IsEdit = true;

            try
            {
                if (ModelState.IsValid)
                {
                    var propertyDto = propertyViewModel.Adapt<PropertyDto>();
                    bool isEDit = await _propertyService.Update(propertyDto);
                    if (isEDit)
                    {

                        return RedirectToAction(nameof(Index));
                    }
                    else
                        return View("Create", propertyViewModel);
                }
                else
                {
                    return View("Create", propertyViewModel);
                }

            }
            catch 
            {
                throw new Exception("error in editing");   
                    }
        }

        public async Task< ActionResult> Delete(int id)
        {
            try
            {
                bool isDeleted = await _propertyService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                throw new Exception("Error in Deleting");
            }
           
        }

       
    }
}
