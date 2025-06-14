namespace MVC.Model.Veiw
{
    public class HomePageViewModel<T>
    {
       // public List<Product>? Products { get; set; }
        public required int CurrentPage { get; set; }
        public required int MaxPage { get; set; }
        public required List<T> Products { get; set; }
    
}
}
