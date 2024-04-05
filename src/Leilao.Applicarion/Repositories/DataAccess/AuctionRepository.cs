using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contexts;
using Leilao.Applicarion.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Applicarion.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly LeilaoDbContext _context;
        public AuctionRepository(LeilaoDbContext context) => _context = context;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;
            return _context
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
