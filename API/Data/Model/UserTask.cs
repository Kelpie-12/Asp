namespace API.Data.Model
{
    public class UserTask
    {
        public  long Id { get; set; }
        public required string Title { get; set; }
        public string? Desc { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;



    }
}
