using Microsoft.EntityFrameworkCore.Query.Internal;
using MVC.Data.Models;
using MVC.Model.DTO;

namespace MVC.Model.Veiw
{
    public class HomePageViewModel
    {
        // public List<Product>? Products { get; set; }
        //public  int CurrentPage { get; set; }
       // public  int MaxPage { get; set; }
       public required Product Product { get; set; }
        public required List<ReviewDTO> Reviews { get; set; }
        public ReviewDTO? ReviewModel { get; set; } = new ReviewDTO() { Author = "", Text = "" };
    }
}
