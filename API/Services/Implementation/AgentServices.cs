using API.Data.Repositories;
using API.Model.Domain;

namespace API.Services.Implementation
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepository _agentRepository;
        public AgentServices(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        public List<Agent> GetAll()
        {
            return _agentRepository.GetAgents();
        }
    }
}
