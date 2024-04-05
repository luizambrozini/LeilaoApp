﻿using Leilao.API.Filters;
using Leilao.Applicarion.UseCases.Offers.CreateOffer;
using Leilao.Comunications.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : LeilaoBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
        {
            var id = useCase.Execute(itemId, request);
            return Created(string.Empty, id);
        }
    }
}
