using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MVC.Model.Domain;
using MVC.Model.Veiw;

namespace MVC.Data.Repositories.Implementations
{
    public class ProductRepository : BaseRepository, IproductRepository
    {
        private readonly IUserReviewRepository _userReviewRepository;

        private const int PRODUCTS_PER_PAGE = 10;

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
                    cmd.CommandText = $"GetAllProducts";

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

        public HomePageViewModel<Product> GetAll(int page)
        {
            if (page < 0)
                throw new ArgumentOutOfRangeException("Page number should be positive");

            List<Product> products = new List<Product>();
            int totalProductCount = 0;

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllProductPage";
                // cmd.CommandText = "SELECT Id, Name, Description, Price FROM Products " +
                //                      "ORDER BY Id OFFSET @skipRows ROWS FETCH NEXT @rowsPerPage ROWS ONLY";

                cmd.Parameters.AddWithValue("@skipRows", page * PRODUCTS_PER_PAGE);
                cmd.Parameters.AddWithValue("@rowsPerPage", PRODUCTS_PER_PAGE);
                //SqlParameter total = new SqlParameter()
                //{
                //    ParameterName = "@totalCountProduct",
                //    SqlDbType = System.Data.SqlDbType.Int,
                //    Direction = System.Data.ParameterDirection.Output
                //};
                //cmd.Parameters.Add(total);
                SqlParameter ret = new SqlParameter()
                {
                    ParameterName = "@return_value",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.ReturnValue
                };
                cmd.Parameters.Add(ret);

                SqlDataReader reader = cmd.ExecuteReader(); 

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product tmp = new Product()
                        {
                            Id = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            Description = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                            Price = reader.GetDecimal(3)
                        };
                        products.Add(tmp);
                    }
                }
                reader.Close();
                cmd.ExecuteNonQuery();
                totalProductCount = (int)ret.Value;
            }


            double maxPage = totalProductCount / PRODUCTS_PER_PAGE;

            return new HomePageViewModel<Product>()
            {
                CurrentPage = page,
                MaxPage = (int)Math.Ceiling(maxPage),
                Products = products
            };
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
                    cmd.CommandText = $"GetProductsById";

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
