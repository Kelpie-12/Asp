using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MVC.Model.Domain;

namespace MVC.Data.Repositories.Implementations
{
    public class ProductRepository : BaseRepository, IproductRepository
    {
        private readonly IUserReviewRepository _userReviewRepository;
        public ProductRepository(IConfiguration configuration, IUserReviewRepository userReviewRepository) : base(configuration)
        {
            _userReviewRepository = userReviewRepository;
        }
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"GetAllProducts";//не может найти хранимую процедуру, но  кверизапрос работает

                    //cmd.CommandText = "use Store  select Products.Id as \'Идентификатор\',Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' ,Products.[Description] as \'Описание\' from Products;";
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
                            product.UserReviews = _userReviewRepository.GetUserReviewsById(product.Id);
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public Product GetById(long id)
        {
            Product product = new Product();            
            using (SqlConnection con = CreateConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = $"GetProductsById";//не может найти хранимую процедуру, но чего кверизапрос работает

                    //cmd.CommandType = System.Data.CommandType.Text;
                    //cmd.CommandText = $"use Store  select Products.Id as \'Идентификатор\'," +
                    //    $"Products.[Name] as \'Название продукта\',Products.Price as \'Цена\' " +
                    //    $",Products.[Description] as \'Описание\' " +
                    //    $"from Products where Products.Id=@id";
                    cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt).Value = id;
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
