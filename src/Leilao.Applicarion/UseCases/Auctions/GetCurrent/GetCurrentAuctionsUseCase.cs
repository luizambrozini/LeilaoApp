using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Applicarion.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionsUseCase
    {
        private readonly IAuctionRepository _auctionRepository;
        public GetCurrentAuctionsUseCase(IAuctionRepository auctionRepository) => _auctionRepository = auctionRepository;

        public Auction? Execute() => _auctionRepository.GetCurrent();

    }
}
