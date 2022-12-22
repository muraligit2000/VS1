using DataLayer;
using HSBC.Deposits.Personnel.Vehicle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.domainModels;
using DataLayer.BusinessModels;
using System.ComponentModel.DataAnnotations;

namespace HSBC.Deposits.Personnel.Vehicle.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class HomeController : BaseController
    {
        private readonly IEmployeeRepository _empRepo;
        public HomeController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<string> arrNames = new List<string>() { "Murali 111", "Krishna 111" };
            return StatusCode(StatusCodes.Status200OK, arrNames);
        }

        // 1 KB = 1024 Bytes

        [HttpPost, Route("save-employee")]
        [SwaggerResponse(400,"Bad Request", typeof(string))]
        public async Task<IActionResult> SaveEmployee([Required]int empno, [Required, MaxLength(10, ErrorMessage = "Max length is 10")] string empname, 
            [MaxLength(5, ErrorMessage = "Max length is 5")] string companyName, [EmailAddress]string BusinessEmail)
        {
            if (ModelState.IsValid)
            {
                var objEmployee = new EmployeeDTO()
                {
                    CompanyId = companyName, //  "ABC Company",
                    EmpNo = empno.ToString(), // "11",
                    Empname = empname // "Murali V"
                };
                await _empRepo.SaveEmloyee(objEmployee);

                return StatusCode(StatusCodes.Status200OK,
                    "Welcome " + empname + ", Your employee number = " + empno.ToString());
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request to this API");
            }
        }

        [HttpGet, Route("get-employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var obj =await _empRepo.GetAllEmloyees();
            return StatusCode(StatusCodes.Status200OK, obj);
        }


        [HttpPost, Route("post-consultant-data")]
        [SwaggerOperation(Summary = "Get AeTm Credentials based on corporatename", Description = "Get AeTm Credentials  based on Profile Type")]
        [SwaggerResponse(200, "Successful", typeof(EmployeeVM))]
        public async Task<IActionResult> PostConsultantData(EmployeeVM objEmployee)
        {
            return StatusCode(StatusCodes.Status200OK,
                "Welcome " + objEmployee.EmpName + ", Your employee number : " + objEmployee.EmpNo.ToString());

        }

        [HttpGet, Route("get-employee")]
        [SwaggerResponse(200, "Successful", typeof(EmployeeVM))]
        public async Task<IActionResult> GetEmployee(int empno)
        {
            var objEmployee = new EmployeeVM()
            {
                EmpNo = 10,
                EmpName = "Murali",
                Department = "Software Engineering"
            };
            return StatusCode(StatusCodes.Status200OK, objEmployee);
        }


        // mcirosoft.entityframeworkcore.tools    mcirosoft.entityframeworkcore.sqlserver

        //        scaffold-dbcontext "data source=DESKTOP-86IH6NM\MSSQLSERVER01;initial catalog=dashboardapp;persist security info=True; Integrated Security=SSPI;" Microsoft.Entityframeworkcore.sqlserver -contextdir context -outputdir domainModels -context "DBContext" -f


        //scaffold-dbcontext "data source=DESKTOP-86IH6NM\MSSQLSERVER01;database=dashboardapp;user id=sa;password=Rama123" Microsoft.Entityframeworkcore.sqlserver -contextdir context -outputdir domainModels -context "DBContext" -f


        //scaffold-dbcontext "data source=DESKTOP-86IH6NM\MSSQLSERVER01;initial catalog=dashboardapp;persist security info=True; Integrated Security=SSPI;" Microsoft.Entityframeworkcore.sqlserver -contextdir context -outputdir domainModels -context "DBContext" -Schema "dbo" -f

    }
}
