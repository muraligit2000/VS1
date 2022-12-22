using EmployeeAPI.ViewModels;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
   // [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class EmployeeController : Controller
    {
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _EmployeeRepository = employeeRepository;
        }

        public IEmployeeRepository _EmployeeRepository;

       // [Authorize(Roles = "admin,superadmin")]
        [HttpGet]
        [Route("get-employees")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(401, "UnAuthorized", typeof(ResponseDTO))]
        public async Task<IActionResult> GetEmployees()
        {

            return Ok(await _EmployeeRepository.GetEmployees());
        }

       // [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("get-employees1")]
        public async Task<IActionResult> GetEmployees1()
        {

            return Ok(await _EmployeeRepository.GetEmployees());
        }
    }
}
