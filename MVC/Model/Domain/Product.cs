namespace MVC.Model.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<UserReview> ?UserReviews { get; set; }
    }
}
