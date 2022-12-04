using AutoMapper;
using Data.context;
using Data.domainModels;
using DataLayer.BusinessModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinqKit;
using System;

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


            //var dtoEmpInnerJoin = await (from p in _DbContext.Emp
            //                    join q in _DbContext.Dept
            //                    on p.Deptno equals q.Deptno
            //                    select p).ToListAsync();


            //var dtoEmpIn_Select = await (from p in _DbContext.Emp
            //                             join q in _DbContext.Dept
            //                             on p.Deptno equals q.Deptno
            //                             select new EmpDTO
            //                             {
            //                                 Empno = p.Empno,
            //                                 Ename = p.Ename,
            //                                 Sal = p.Sal,
            //                                 Comm = p.Comm,
            //                                 Deptno = q.Deptno,
            //                                 Deptname = q.Dname,
            //                                 Location = q.Loc
            //                             }
            //                             ).ToListAsync();

            //var dtoEmpOuter_Select = await (from emp in _DbContext.Emp
            //                             join dept in _DbContext.Dept
            //                             on emp.Deptno equals dept.Deptno into outer_emp
            //                             from dept_out in outer_emp.DefaultIfEmpty()
            //                             select new EmpDTO
            //                             {
            //                                 Empno = emp.Empno,
            //                                 Ename = emp.Ename,
            //                                 Sal =   emp.Sal,
            //                                 Comm =  emp.Comm,
            //                                 Deptno =   dept_out.Deptno,
            //                                 Deptname = dept_out.Dname,
            //                                 Location = dept_out.Loc
            //                             }
            //                             ).ToListAsync();

            try
            {

                var dtoEmpgroupBy1 = await (from p in _DbContext.Emp.GroupBy(x => x.Deptno)
                                            select new
                                            {
                                                deptno = p.Key,
                                                HeadCount = p.Count()
                                            }
                                            ).ToListAsync();

                var dtoEmpgroupBy2 = await (from p in _DbContext.Emp.GroupBy(x => new { x.Deptno, x.Job })
                                            select new
                                            {
                                                deptno = p.Key.Deptno,
                                                Job = p.Key.Job,
                                                HeadCount = p.Count()
                                            }
                                           ).ToListAsync();

                string ename = string.Empty;
                int eno = 0;
                string job = "SALESMAN";
                int deptno = 30;

                var predicate = PredicateBuilder.New<EmpDTO>(true);

                if (!string.IsNullOrWhiteSpace(ename))
                    predicate = predicate.And(x => x.Ename == ename);
                if (eno > 0)
                    predicate = predicate.And(x => x.Empno == eno);
                if (!string.IsNullOrWhiteSpace(job))
                {
                    predicate = predicate.And(x => x.Job == job);
                    if (deptno > 0)
                        predicate = predicate.Or(x => x.Deptno == deptno);
                }

                var dtoEmppred = await (from emp in _DbContext.Emp
                                        select new EmpDTO
                                        {
                                            Empno = emp.Empno,
                                            Ename = emp.Ename,
                                            Sal = emp.Sal,
                                            Comm = emp.Comm,
                                            Job = emp.Job,
                                            Mgr = emp.Mgr,
                                            Hiredate = emp.Hiredate,
                                            Deptno = emp.Deptno
                                        }
                                        ).Where(predicate).ToListAsync();



            }
            catch (Exception ex)
            {
                string str1 = ex.StackTrace;
            }

            var dtoEmp = await _DbContext.Employee.Select(
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
            return dtoEmp;




        }
    }
}
