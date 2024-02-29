using SubscribersAPI.DTOs;
using SubscribersAPI.Models;

namespace SubscribersAPI.Services
{
    public interface ISubscriberService
    {
        public Task<bool> SubscriberExistsAsync(int id);
        Task<List<Subscriber>> GetAllSubscribersAsync();
        Task<Subscriber?> GetSubscriberByIdAsync(int id);
        Task<Subscriber> CreateSubscriberAsync(CreateSubscriberDTO sub);
        Task<Subscriber?> UpdateSubscriberAsync(int id, UpdateSubscriberDTO sub);
        Task<bool> DeleteSubscriberAsync(int id);
        Task<Subscriber?> AddChannelToUserAsync(int id, AddChannelDto channel);
    }
}
