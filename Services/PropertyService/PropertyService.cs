using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;
using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Emoloyee_Property_Mangment_Task.Services.PropertyService
{
    public class PropertyService : IPropertyService
    {
        IRepository<Property> _propertyRepo;
        public PropertyService(IRepository<Property> propertyRepo
           )
        {
            _propertyRepo = propertyRepo;
        }

        public IQueryable<PropertyDto> GetAll() {
            return _propertyRepo.GetAll().
                ProjectToType<PropertyDto>().AsNoTracking();

        
        }
        public async Task<bool> Add(PropertyDto propertyDto)
        {
            try
            {
                var property = propertyDto.Adapt<Property>();
                _propertyRepo.Add(property);
                await _propertyRepo.SaveChanges();
                return true;
            }
            catch { 
                return false;
            }

        }
        public async Task<bool> Update(PropertyDto propertyDto)
        {
            try 
            {
                _propertyRepo.Update(propertyDto.Adapt<Property>());
               await _propertyRepo.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public PropertyDto GetById(int id) {

            return _propertyRepo.GetByID(id)
                      .Adapt<PropertyDto>();
        }
    
        public async Task<bool> Delete (int id)
        {
            try
            {
                _propertyRepo.Delete(id);
                await _propertyRepo.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
     


    }
}
