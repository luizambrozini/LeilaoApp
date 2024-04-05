using Leilao.Applicarion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.Applicarion.Repositories.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer);
    }
}
