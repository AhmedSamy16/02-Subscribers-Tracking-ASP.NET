using Microsoft.EntityFrameworkCore;
using SubscribersAPI.Models;

namespace SubscribersAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
