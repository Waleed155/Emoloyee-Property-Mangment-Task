using Emoloyee_Property_Mangment_Task.Models;
using Emoloyee_Property_Mangment_Task.Repository;
using Emoloyee_Property_Mangment_Task.Dto;
using Emoloyee_Property_Mangment_Task.Dto.EmployeeDto;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Emoloyee_Property_Mangment_Task.Dto.PropertyDto;
using Emoloyee_Property_Mangment_Task.Dto.EmployeePropertyDto;

using Emoloyee_Property_Mangment_Task.ViewModel;
using System.Security.Cryptography;


namespace Emoloyee_Property_Mangment_Task.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeePropertyRepository _empPropRepo;
        IRepository<Employee> _empRepository;
        IRepository<EmployeeProperty> _empPropertyRepository;
        IEmpRepository _empRepo;
        IRepository<Property> _PropertyRepository;

        public EmployeeService(IRepository<Employee> empRepository,
            IRepository<Property> PropertyRepository,
            IEmpRepository empRepo, IRepository<EmployeeProperty> empPropertyRepository,
            IEmployeePropertyRepository empPropRepo
            ) {
            _empRepository = empRepository;
            _PropertyRepository = PropertyRepository;
            _empRepo = empRepo;
            _empPropertyRepository = empPropertyRepository;
            _empPropRepo = empPropRepo;
        }
        public IQueryable<EmployeeDto> GetAll()
        {

            TypeAdapterConfig<Employee, EmployeeDto>.
            NewConfig().
             Map(dst => dst.EmployeeProperties,
             src => src.EmployeeProperties
             .Adapt<HashSet<EmployeePropertyDto>>());

            return _empRepo.GetAll().ProjectToType<EmployeeDto>();
         }
        public EmployeeAddDto GetFormAddEmployee()
        {
            var properties = _PropertyRepository.GetAll().ProjectToType<PropertyAddDto>();
            EmployeeAddDto addForm = new EmployeeAddDto()
            {
                Properties = properties.ToHashSet()
            };
            return addForm;
        }
        public async Task<bool> Add(EmployeeAddDto employeeAddDto)
        {
            try
            {
                var employee = _empRepository.
                       Add(employeeAddDto.Adapt<Employee>());
                await _empRepository.SaveChanges();

                foreach (var prop in employeeAddDto.Properties)
                {
                    var employeePropertyAddDto = new EmployeePropertyAddDto()
                    {
                        PropertyId = prop.Id,
                        EmployeeId = employee.Id,
                        Value = prop.Value
                    };
                    _empPropertyRepository.
                        Add(employeePropertyAddDto.
                        Adapt<EmployeeProperty>());
                }
                await _empPropertyRepository.SaveChanges();
                return true;
            }
            catch  {
                return false;
            }

        }

        public EmployeeAddDto GetById(int id)
        {
            var employee = _empRepo.Get(id);
            var properties = _PropertyRepository.GetAll().ProjectToType<PropertyAddDto>();
            var employeeAddDto =employee.Adapt<EmployeeAddDto>();
            HashSet<PropertyAddDto> propAddList = new HashSet<PropertyAddDto>();
            if (employeeAddDto.Id != 0&& properties.Count()>0 )
            {
                foreach ( var prop in properties) {
                foreach (var empProperty in employee.EmployeeProperties)
                {
                        if (prop.Id == empProperty.PropertyId)
                        {
                            prop.Value = empProperty.Value;
                        }
                   }
                     propAddList.Add(prop);

                }
                employeeAddDto.Properties = propAddList;
                return employeeAddDto;
            }
            else
                return new EmployeeAddDto();
            }
        public async Task<bool> Edit(EmployeeAddDto employeeAddDto)
        {
            try
            {
                foreach (var empProperty in employeeAddDto.Properties)
                {
                    var employeeProperty = _empPropRepo.Get(employeeAddDto.Id, empProperty.Id);
                    employeeProperty.Value = empProperty.Value;
                    _empPropertyRepository.Update(employeeProperty);
                }

            var employee=  _empRepository.GetByID(employeeAddDto.Id);
                employee.Code = employeeAddDto.Code;
                employee.Name=employeeAddDto.Name;
              await  _empRepository.SaveChanges();
                await _empPropertyRepository.SaveChanges();



                return true;
            }
            catch  { return false; }
        }
        public async Task<bool> Delete (int id)
        {
            try
            {
                if (_empRepository.Delete(id))
                {
                    await _empRepository.SaveChanges();
                    var empProps = _empPropRepo.GetValuesByEmpID(id).ToList();
                    foreach (var empProp in empProps)
                    {
                        _empPropertyRepository.Delete(empProp.Id);

                    }
                    await _empPropertyRepository.SaveChanges();
                    return true;
                }
                else
                    { return false; }
            }catch
            {
                return false;
            }
        }

            
    }
}
