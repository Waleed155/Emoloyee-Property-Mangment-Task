using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;
using Mapster;

namespace Emoloyee_Property_Mangment_Task.Services.PropertyService
{
    public interface IPropertyService
    {
        public IQueryable<PropertyDto> GetAll();
        public Task<bool> Add(PropertyDto propertyDto);
        public Task<bool> Update(PropertyDto propertyDto);
        public PropertyDto GetById(int id);
        public  Task<bool> Delete(int id);
    }
}
