using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Models.Employee;
using Product.Repository.Interface;

namespace Product.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(IEmployee employee, ILogger<EmployeeController> logger)
        {
            this.employee = employee;
            this.logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public IActionResult List()
        {
            string userName = "KSAdmin";
            string iPAddress = "::1";
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = employee.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeletedList()
        {
            string userName = "KSAdmin";
            string iPAddress = "::1";
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = employee.DeletedList(userName);
            logger.LogInformation($"Result: {result}");
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetByCode(int employeeId)
        {
            string userName = "KSAdmin";
            string iPAddress = "::1";
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = employee.GetByCode(employeeId,userName);
            logger.LogInformation($"Result:{result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Insert(EmployeeDTOAdd employeeAddDTO)
        {
            string createdBy = "KSAdmin";
            string creadtedByIpAddress = "::1";
            logger.LogInformation($"|Request:Created By:{createdBy},IP:{creadtedByIpAddress}");
            var result = employee.Insert(employeeAddDTO);
            logger.LogInformation($"Result:{result}");
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Update(EmployeeDTOEdit employeeEditDTO)
        {
            string userName = "KSAdmin";
            string iPAddress = "::1";
            logger.LogInformation($"|Request:User{userName},IP:{iPAddress}");
            var result = employee.Update(employeeEditDTO);
            logger.LogInformation($"Result:{result}");
            return Ok(result);
        }

        [HttpPost("{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Delete(int employeeId)
        {
            string deletedBy = "KSAdmin";
            string deletedByIpAddress = "::1";
            logger.LogInformation($"|Request:User{deletedBy},IP:{deletedByIpAddress}");
            var result = employee.Delete(employeeId, deletedBy, deletedByIpAddress);
            logger.LogInformation($"Result:{result}");
            return Ok(result);
        }


    }
}
