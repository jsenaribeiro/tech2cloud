using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

/// <summary>
/// Controller for managing cart operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CartsController : BaseController
{
   private readonly IMediator _mediator;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of CartsController
   /// </summary>
   /// <param name="provider">Service provider for dependency injection</param>
   public CartsController(IServiceProvider provider)
   {
      _mediator = provider.GetRequiredService<IMediator>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Retrieves a cart by their ID
   /// </summary>
   /// <param name="id">The unique identifier of the cart</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The cart details if found</returns>
   [HttpGet("{id}")]
   [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetCart([FromRoute] int id, CancellationToken cancellationToken)
   {
      var request = new GetCartRequest(id);
      var validator = new GetCartRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var query = _mapper.Map<GetCartQuery>(request.Id);
      var result = await _mediator.Send(query, cancellationToken);

      return Ok(_mapper.Map<GetCartResponse>(result));
   }

   /// <summary>
   /// Retrieves carts by filter
   /// </summary>
   /// <param name="filter">Query filter for carts</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The cart details if found</returns>
   [HttpGet()]
   [ProducesResponseType(typeof(ApiResponseWithData<GetCartsResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetCarts([FromQuery] QueryFilter filter, CancellationToken cancellationToken)
   {
      var request = new GetCartsRequest(filter);
      var query = _mapper.Map<GetCartsQuery>(request);
      var result = await _mediator.Send(query, cancellationToken);
      var response = _mapper.Map<PageList<GetCartsResponse>>(result);

      return OkPaginated(response);
   }

   /// <summary>
   /// Creates a new cart
   /// </summary>
   /// <param name="request">The cart creation request</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created cart details</returns>
   [HttpPost]
   [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
   {
      var validator = new CreateCartRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<CreateCartCommand>(request);
      var response = await _mediator.Send(command, cancellationToken);

      return Created(string.Empty, _mapper.Map<CreateCartResponse>(response));
   }

   /// <summary>
   /// Updates a cart
   /// </summary>
   /// <param name="id">The unique identifier of the cart</param>
   /// <param name="request">The cart update request</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated cart details</returns>
   [HttpPut("{id}")]
   [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> UpdateCart([FromRoute] int id, [FromBody] UpdateCartRequest request, CancellationToken cancellationToken)
   {
      var validator = new UpdateCartRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<UpdateCartCommand>(request);
      command.Id = id;
      
      var response = await _mediator.Send(command, cancellationToken);

      return Ok(_mapper.Map<UpdateCartResponse>(response));
   }

   /// <summary>
   /// Deletes a user by their ID
   /// </summary>
   /// <param name="id">The unique identifier of the user to delete</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>Success response if the user was deleted</returns>
   [HttpDelete("{id}")]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> DeleteUser([FromRoute] int id, CancellationToken cancellationToken)
   {
      var request = new DeleteCartRequest(id);
      var validator = new DeleteCartRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<DeleteCartCommand>(request.Id);
      await _mediator.Send(command, cancellationToken);

      return Ok(new ApiResponse
      {
         Success = true,
         Message = "Cart deleted successfully"
      });
   }
}
