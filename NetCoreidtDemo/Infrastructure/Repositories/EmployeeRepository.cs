using Data.context;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmpDBContext _empDbContext;
        private readonly IConfiguration _config;
        public EmployeeRepository(EmpDBContext empDbContext, IConfiguration config)
        {
            _empDbContext = empDbContext;
            _config = config;
        }
        public async Task<List<TravelHubTileCaptions>> GetEmployees()
        {
            //return await
            //    (from x in _empDbContext.Employee
            //     select new EmployeeDTO
            //     {
            //         CompanyId = x.CompanyId,
            //         Empname = x.Empname,
            //         EmpNo = x.EmpNo,
            //         Gender = x.Gender
            //     }).ToListAsync();

            //string LangCode = "fr-FR";
            //string LangCode = "en-GB";
            string LangCode = "en-CA";

            var empData = await (
                from p in _empDbContext.Employee.Where(x => x.CompanyId == "en-GB" && !string.IsNullOrWhiteSpace(x.EmpNo))
                join q in _empDbContext.Employee.Where(x => x.CompanyId == LangCode && !string.IsNullOrWhiteSpace(x.EmpNo))
                on p.EmpNo equals q.EmpNo into outer_emp
                from emp_out in outer_emp.DefaultIfEmpty()
                select new TravelHubTileCaptions
                {
                    LanguageCode = emp_out.CompanyId ?? p.CompanyId,
                    EnglishData = emp_out.EmpNo ?? p.EmpNo,
                    OtherLanguageData = emp_out.ResAddress ?? p.EmpNo
                }
                ).ToListAsync();

            return empData;
        }
    }
}
