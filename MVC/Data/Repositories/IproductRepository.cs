using MVC.Model.Domain;

namespace MVC.Data.Repositories
{
    public interface IproductRepository
    {
        List<Product> GetAll();
        Product GetById(long id);
    }
}
