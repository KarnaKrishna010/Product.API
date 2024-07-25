using AutoMapper;
using Product.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Product.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActController : ControllerBase
    {
        private readonly IAct act;
        private readonly ILogger<ActController> logger;
        public ActController(IAct act, ILogger<ActController> logger)
        {
            this.act = act;
            this.logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult List()
        {
            string userName = "KSAdmin";
            string iPAddress = "::1";
            logger.LogInformation($"|Request:User:{userName},IP:{iPAddress}");
            var result = act.List(userName);
            logger.LogInformation($"|Result: {result}");
            return Ok(result);
        }
    }
}