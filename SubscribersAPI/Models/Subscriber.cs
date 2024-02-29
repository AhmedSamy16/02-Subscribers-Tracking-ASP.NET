using System.ComponentModel.DataAnnotations;

namespace SubscribersAPI.Models
{
    public class Subscriber
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<string> Channels { get; set; } = [];
    }
}
