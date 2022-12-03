using AutoMapper;
using Data.context;
using Data.domainModels;
using DataLayer.BusinessModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinqKit;

namespace DataLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DBContext _DbContext;
        private readonly IMapper _mapper;
        public EmployeeRepository(DBContext dbcontext, IMapper mapper)
        {
            _DbContext = dbcontext;
            _mapper = mapper;
        }

        public async Task SaveEmloyee(EmployeeDTO dto)
        {
            //var dtoEmp = new Employee();
            //dtoEmp.CompanyId = dto.CompanyId;
            //dtoEmp.EmpNo = dto.EmpNo;
            //dtoEmp.Empname = dto.Empname;
            //dtoEmp.Gender = dto.Gender;
            //dtoEmp.ResAddress = dto.ResAddress;

            var empDb = _DbContext.Employee.Where(x => x.EmpNo == dto.EmpNo).FirstOrDefault();
            if (empDb != null)
            {
                empDb.Empname = dto.Empname;
                empDb.CompanyId = dto.CompanyId;
                _DbContext.Update<Employee>(empDb);
            }
            else
            {
                var dtoEmp = _mapper.Map<EmployeeDTO, Employee>(dto);
                _DbContext.Add<Employee>(dtoEmp);
            }

            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<EmployeeDTO>> GetAllEmloyees()
        {
            //var empDb = _DbContext.Employee.ToList();
            //List<EmployeeDTO> dtoEmp = _mapper.Map<List<Employee>, List<EmployeeDTO>>(empDb);
            //return dtoEmp;

            //var dtoEmp = (from p in _DbContext.Employee
            //              select new EmployeeDTO()
            //              {
            //                  Id = p.Id,
            //                  EmpNo = p.EmpNo,
            //                  Empname = p.Empname,
            //                  Gender = p.Gender,
            //                  CompanyId = p.CompanyId,
            //                  ResAddress = p.ResAddress
            //              }
            //             ).ToList();
            //return dtoEmp;

            return await  _DbContext.Employee.Select(
                          p => new EmployeeDTO
                          {
                              Id = p.Id,
                              EmpNo = p.EmpNo,
                              Empname = p.Empname,
                              Gender = p.Gender,
                              CompanyId = p.CompanyId,
                              ResAddress = p.ResAddress
                          }
                         ).OrderBy(x => x.Empname).ThenBy(y => y.CompanyId).ToListAsync();
            //return dtoEmp;
        }
    }
}
