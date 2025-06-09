using Microsoft.AspNetCore.Mvc;
using MVC.Model.Domain;

namespace MVC.Services
{
    public interface ISqlDbServices
    {
        List<Product> GetAllProducts(/*[FromServices] IConfiguration _configuration*/);
        Product GetProductsById(long id);

    }
}
