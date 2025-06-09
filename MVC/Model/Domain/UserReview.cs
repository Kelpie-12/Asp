namespace MVC.Model.Domain
{
    public class UserReview
    {
        public int Id { get; set; }
        public long IdProduct { get; set; } = -1;
        public string? UserName { get; set; }

        public int Mark { get; set; }
        public string? Desc { get; set; }
        public UserReview(UserReview review)
        {
            if (review.Id != null)
            {
                Id = review.Id;
            }
            Id = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            UserName = review.UserName;
            Mark = review.Mark;
            Desc = review.Desc;
        }
        public UserReview() { }
    }
}
