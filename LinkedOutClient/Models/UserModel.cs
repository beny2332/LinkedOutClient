using System.ComponentModel.DataAnnotations;

namespace LinkedOutClient.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }
        public string? userName { get; set; }
    }
}
