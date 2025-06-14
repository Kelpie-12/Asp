using EntitiFramework.Data;
using EntitiFramework.Model;

namespace EntitiFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationDbContext db=new ApplicationDbContext())
            {
                List<Products> product = db.Products.ToList();
                foreach (Products item in product)
                {
                    Console.WriteLine("Products => " + item.Id + " "+ item.Name);
                    foreach(var i in item.UserReviews)
                    {
                        Console.WriteLine("Review" +i.UserName);
                    }
                }
            }

        }
    }
}
