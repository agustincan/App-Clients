using Microsoft.AspNetCore.Mvc;

namespace Client.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            // this is just for state testing
            return "Running ...";
        }
    }
}