namespace MVC.Model
{
    public class UserReview
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string? Title { get; set; }
        public string? Desc { get; set; }
    }
}
