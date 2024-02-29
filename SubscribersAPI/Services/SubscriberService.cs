using Microsoft.EntityFrameworkCore;
using SubscribersAPI.Data;
using SubscribersAPI.DTOs;
using SubscribersAPI.Models;

namespace SubscribersAPI.Services
{
    public class SubscriberService(ApplicationDbContext context) : ISubscriberService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Subscriber?> AddChannelToUserAsync(int id, AddChannelDto channel)
        {
            var sub = await GetSubscriberByIdAsync(id);
            if (sub is null)
                return null;

            sub.Channels.Add(channel.Channel);
            await _context.SaveChangesAsync();
            return sub;
        }

        public async Task<Subscriber> CreateSubscriberAsync(CreateSubscriberDTO sub)
        {
            var subscriber = new Subscriber()
            {
                Name = sub.Name,
                Channels = sub.Channels,
            };
            await _context.Subscribers.AddAsync(subscriber);
            await _context.SaveChangesAsync();

            return subscriber;
        }

        public async Task<bool> DeleteSubscriberAsync(int id)
        {
            var sub = await _context.Subscribers.FirstOrDefaultAsync(s => s.Id == id);
            if (sub is null)
                return false;

            _context.Subscribers.Remove(sub);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<List<Subscriber>> GetAllSubscribersAsync()
        {
            return _context.Subscribers.ToListAsync();
        }

        public Task<Subscriber?> GetSubscriberByIdAsync(int id)
        {
            return _context.Subscribers.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> SubscriberExistsAsync(int id)
        {
            return await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id) != null;
        }

        public async Task<Subscriber?> UpdateSubscriberAsync(int id, UpdateSubscriberDTO sub)
        {
            var existingSub = await GetSubscriberByIdAsync(id);
            if (existingSub is null)
                return null;

            existingSub.Name = sub.Name;

            await _context.SaveChangesAsync();

            return existingSub;
        }
    }
}
