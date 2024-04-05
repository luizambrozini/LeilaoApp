using Leilao.Applicarion.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Applicarion.Repositories.Contexts
{
    public class LeilaoDbContext : DbContext
    {
        public LeilaoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}
