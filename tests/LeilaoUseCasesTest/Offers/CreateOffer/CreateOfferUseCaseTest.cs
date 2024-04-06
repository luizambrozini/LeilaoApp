using Bogus;
using FluentAssertions;
using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contracts;
using Leilao.Applicarion.Services;
using Leilao.Applicarion.UseCases.Auctions.GetCurrent;
using Leilao.Applicarion.UseCases.Offers.CreateOffer;
using Leilao.Comunications.Requests;
using Moq;
using Xunit;

namespace LeilaoUseCases.Test.Offers.CreateOffer
{

    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            //AAA
            //Arrange
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

            var offerRepository = new Mock<IOfferRepository>();
            var loggerUser = new Mock<ILoggedUser>();
            loggerUser.Setup(i => i.User()).Returns(new User());
            var useCase = new CreateOfferUseCase(loggerUser.Object, offerRepository.Object);

            //Act
            var act = () => useCase.Execute(itemId, request);

            //Assert
            act.Should().NotThrow();

        }
    }
}
