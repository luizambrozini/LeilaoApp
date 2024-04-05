using Leilao.Applicarion.Entities;

namespace Leilao.Applicarion.Repositories.Contracts
{
    public interface IAuctionRepository
    {
        Auction? GetCurrent();
    }
}
