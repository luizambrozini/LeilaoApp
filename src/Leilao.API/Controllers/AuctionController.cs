using Leilao.Applicarion.Entities;
using Leilao.Applicarion.UseCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers
{

    public class AuctionController : LeilaoBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuctions([FromServices] GetCurrentAuctionsUseCase useCase)
        {
            var result = useCase.Execute();
            if (result is null) return NoContent();
            return Ok(result);
        }


    }
}
