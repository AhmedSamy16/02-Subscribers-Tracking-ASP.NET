namespace SubscribersAPI.DTOs
{
    public class CreateSubscriberDTO
    {
        public string Name { get; set; }
        public List<string> Channels { get; set; } = [];
    }
}
