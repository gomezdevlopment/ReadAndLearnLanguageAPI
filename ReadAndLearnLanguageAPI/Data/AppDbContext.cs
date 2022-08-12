using Microsoft.EntityFrameworkCore;
using ReadAndLearnLanguageAPI.Model;

namespace ReadAndLearnLanguageAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserWord> Words { get; set; }
        public DbSet<UserText> Texts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}