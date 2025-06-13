using MVC.Model.Domain;
using MVC.Model.Veiw;

namespace MVC.Data.Repositories
{
    public interface IproductRepository
    {
        List<Product> GetAll();
        Product GetById(long id);
        HomePageViewModel<Product> GetAll(int page);
    }
}
