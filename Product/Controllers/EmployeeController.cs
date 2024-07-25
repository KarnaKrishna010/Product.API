using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
