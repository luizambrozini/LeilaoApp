using Bogus;
using FluentAssertions;
using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contracts;
using Leilao.Applicarion.UseCases.Auctions.GetCurrent;
using Leilao.Comunications.Enums;
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
            var auctionEntity = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 10))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = f.Random.Number(1,10),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(50,9000),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();
            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(auctionEntity);
            var useCase = new GetCurrentAuctionsUseCase(mock.Object);
            //Act
            var auction = useCase.Execute();
            //Assert
            auction.Should().NotBeNull();
            auction.Id.Should().Be(auctionEntity.Id);
            auction.Name.Should().Be(auctionEntity.Name);
        }
    }
}
