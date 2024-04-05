using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contexts;
using Leilao.Applicarion.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.Applicarion.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly LeilaoDbContext _context;
        public OfferRepository(LeilaoDbContext context) => _context = context;

        public void Add(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }
    }
}
