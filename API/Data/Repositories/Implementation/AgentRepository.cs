using API.Model.Domain;
using Microsoft.Data.SqlClient;

namespace API.Data.Repositories.Implementation
{
    public class AgentRepository : BaseRepository, IAgentRepository
    {
        public AgentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Agent> GetAgents()
        {
            List<Agent> agents = new List<Agent>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"get_all_manager";
                    cmd.Parameters.Add(new SqlParameter("@archive", 1));

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Agent agent = new Agent()
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2)
                            };
                            agents.Add(agent);
                        }
                    }
                }
            }
            return agents;
        }
    }
}
