using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
   [ApiController]
   [Route("api/[controller]")]
   public class SalesController : ControllerBase
   {
      private readonly IMediator _mediator;
      private readonly IMapper _mapper;

      public SalesController(IServiceProvider provider)
      {
         _mediator = provider.GetRequiredService<IMediator>();
         _mapper = provider.GetRequiredService<IMapper>();
      }

      /// <summary>
      /// Creates a new sale
      /// </summary>
      /// <param name="request">The sale creation request</param>
      /// <param name="cancellationToken">Cancellation token</param>
      /// <returns>The created sale details</returns>
      [HttpPost]
      [ProducesResponseType(typeof(ApiResponseWithData<string>), StatusCodes.Status201Created)]
      [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
      public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
      {
         var validator = new CreateSaleRequestValidator();
         var validationResult = await validator.ValidateAsync(request, cancellationToken);

         if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

         var command = _mapper.Map<CreateSaleCommand>(request);
         var response = await _mediator.Send(command, cancellationToken);

         return Created(string.Empty, response);
      }
   }
}