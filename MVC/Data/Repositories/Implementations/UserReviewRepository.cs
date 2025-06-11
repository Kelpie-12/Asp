
using Microsoft.Data.SqlClient;
using MVC.Model.Domain;

namespace MVC.Data.Repositories.Implementations
{
    public class UserReviewRepository : BaseRepository, IUserReviewRepository
    {
        public UserReviewRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public List<UserReview> GetUserReviewsById(long id)
        {
            List<UserReview> reviews = new List<UserReview>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"use Store select UR.ReviewId ,UR.ProductId,UR.Mark,UR.[Description],UR.UserName from UserReview as UR where UR.ProductId={id}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserReview review = new UserReview()
                            {
                                Id = (int)reader[0],
                                IdProduct = (long)reader[1],
                                Mark = (int)reader[2],
                                Desc = reader[3].ToString(),
                                UserName = reader[4].ToString()
                            };
                            reviews.Add(review);
                        }
                    }
                }
            }
            return reviews;
        }

    }
}
