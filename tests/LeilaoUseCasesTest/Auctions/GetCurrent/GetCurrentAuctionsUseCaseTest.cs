using FluentAssertions;
using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contracts;
using Leilao.Applicarion.UseCases.Auctions.GetCurrent;
using Moq;
using Xunit;

namespace LeilaoUseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionsUseCaseTest
    {
        [Fact]
        public void Success()
        {
            //AAA
            //Arrange
            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(new Auction());
            var useCase = new GetCurrentAuctionsUseCase(mock.Object);
            //Act
            var auction = useCase.Execute();
            //Assert
            auction.Should().NotBeNull();

        }
    }
}
