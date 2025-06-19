using API.Model.Domain;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyTestController : ControllerBase
    {
        private readonly IAgentServices _agentServices;
        public MyTestController(IAgentServices agentServices)
        {
            _agentServices = agentServices;
        }

        [HttpGet(Name = "GetAllAgent")]
        public List<Agent> Get()
        {
            return _agentServices.GetAll();
        }
    }
}
