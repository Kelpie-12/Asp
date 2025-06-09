using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC.Model.Domain;

namespace MVC.Services.Implementation
{
    public class SqlDbServices : ISqlDbServices
    {
        private readonly IConfiguration _configuration;
        public SqlDbServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Product> GetAllProducts(/*[FromServices] IConfiguration _configuration*/)
        {
            List<Product> products = new List<Product>();          
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Test")))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = $"GetAllProducts";//не может найти хранимую процедуру, но  кверизапрос работает

                    cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Product product = new Product()
                            {
                                Id = (long)reader[0],
                                Name = reader[1].ToString(),
                                Price = (decimal)reader[2],
                                Description = reader[3].ToString()                                
                            };
                            product.UserReviews = GetUserReviewsById(product.Id);
                            products.Add(product);
                        }
                    }                  
                }
            }

            return products;
        }
        private List<UserReview> GetUserReviewsById(long id)
        {
            List<UserReview> reviews = new List<UserReview>();     
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Test")))
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
        public Product GetProductsById(long id)
        {
            Product product = new Product();
            string a = _configuration.GetConnectionString("Test");
            using (SqlConnection con = new SqlConnection(a))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = $"GetAllProducts";//не может найти хранимую процедуру, но чего кверизапрос работает

                    cmd.CommandText = $"use Store  select Products.Id as \'Идентификатор\'," +
                        $"Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' " +
                        $",Products.[Description] as \'Описание\' " +
                        $"from Products where Products.Id={id}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            product.Id = (long)reader[0];
                            product.Name = reader[1].ToString();
                            product.Price = (decimal)reader[2];
                            product.Description = reader[3].ToString();
                        }
                    }
                }
            }

            return product;
        }
    }
}
