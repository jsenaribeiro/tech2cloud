using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProductCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductsByCategory;
using Ambev.DeveloperEvaluation.Application.Products.GetProductsByCategory;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProductCategories;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing product operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
   private readonly IMediator _mediator;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of ProductsController
   /// </summary>
   /// <param name="mediator">The mediator instance</param>
   /// <param name="mapper">The AutoMapper instance</param>
   public ProductsController(IMediator mediator, IMapper mapper)
   {
      _mediator = mediator;
      _mapper = mapper;
   }

   /// <summary>
   /// Retrieves a product by their ID
   /// </summary>
   /// <param name="id">The unique identifier of the product</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The product details if found</returns>
   [HttpGet("{id}")]
   [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetProduct([FromRoute] int id, CancellationToken cancellationToken)
   {
      var request = new GetProductRequest(id);
      var validator = new GetProductRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var query = _mapper.Map<GetProductQuery>(request.Id);
      var result = await _mediator.Send(query, cancellationToken);

      return Ok(_mapper.Map<GetProductResponse>(result));
   }

   /// <summary>
   /// Retrieves products by filter
   /// </summary>
   /// <param name="filter">Query filter for products</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The product details if found</returns>
   [HttpGet()]
   [ProducesResponseType(typeof(ApiResponseWithData<GetProductsResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetProducts([FromQuery] QueryFilter filter, CancellationToken cancellationToken)
   {
      var request = new GetProductsRequest(filter);
      var query = _mapper.Map<GetProductsQuery>(request);
      var result = await _mediator.Send(query, cancellationToken);
      var response = _mapper.Map<PageList<GetProductsResponse>>(result);

      return OkPaginated(response);
   }

   /// <summary>
   /// Retrieves all product categories
   /// </summary>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The product categories details if found</returns>
   [HttpGet("Category")]
   [ProducesResponseType(typeof(ApiResponseWithData<string[]>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetProductCategories(CancellationToken cancellationToken)
   {
      var request = new GetProductCategoriesRequest();
      var query = _mapper.Map<GetProductCategoriesQuery>(request);
      var result = await _mediator.Send(query, cancellationToken);

      return Ok(result, true);
   }

   /// <summary>
   /// Retrieves products of an specific category
   /// </summary>
   /// <param name="category">Product category name</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The product details if found</returns>
   [HttpGet("Category/{category}")]
   [ProducesResponseType(typeof(ApiResponseWithData<GetProductsByCategoryResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetProductsByCategory([FromRoute] string category, [FromQuery] QueryFilter filter, CancellationToken cancellationToken)
   {
      var request = new GetProductsByCategoryRequest(category, filter);
      var query = _mapper.Map<GetProductsByCategoryQuery>(request);
      var result = await _mediator.Send(query, cancellationToken);
      var response = _mapper.Map<PageList<GetProductsByCategoryResponse>>(result);

      return OkPaginated(response);
   }

   /// <summary>
   /// Creates a new product
   /// </summary>
   /// <param name="request">The product creation request</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created product details</returns>
   [HttpPost]
   [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
   {
      var validator = new CreateProductRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<CreateProductCommand>(request);
      var response = await _mediator.Send(command, cancellationToken);

      return Created(string.Empty, _mapper.Map<CreateProductResponse>(response));
   }

   /// <summary>
   /// Updates a product
   /// </summary>
   /// <param name="id">The unique identifier of the product</param>
   /// <param name="request">The product update request</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated product details</returns>
   [HttpPut("{id}")]
   [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
   {
      var validator = new UpdateProductRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<UpdateProductCommand>(request);
      command.Id = id;
      
      var response = await _mediator.Send(command, cancellationToken);

      return Ok(_mapper.Map<UpdateProductResponse>(response));
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
      var request = new DeleteProductRequest(id);
      var validator = new DeleteProductRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<DeleteProductCommand>(request.Id);
      await _mediator.Send(command, cancellationToken);

      return Ok(new ApiResponse
      {
         Success = true,
         Message = "Product deleted successfully"
      });
   }
}
