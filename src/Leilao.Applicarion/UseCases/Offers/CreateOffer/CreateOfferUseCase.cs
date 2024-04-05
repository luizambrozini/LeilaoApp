using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories;
using Leilao.Applicarion.Repositories.Contracts;
using Leilao.Applicarion.Services;
using Leilao.Comunications.Requests;



namespace Leilao.Applicarion.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;

        public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
            _loggedUser = loggedUser;
        }

        public int Execute(int itemId, RequestCreateOfferJson request)
        {

            var user = _loggedUser.User();
            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };

            _offerRepository.Add(offer);

            return offer.Id;
        }
    }
}
