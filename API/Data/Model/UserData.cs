using System.ComponentModel.DataAnnotations;

namespace API.Data.Model
{
    public class UserData
    {
        [Key]
        public required string Key { get; set; }

        public required string Value { get;set; }
    }
}
