using API.Model.Domain;

namespace API.Data.Repositories
{
    public interface IAgentRepository
    {
        List<Agent> GetAgents();
    }
}
