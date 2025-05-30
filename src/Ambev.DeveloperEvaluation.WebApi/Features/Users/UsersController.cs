using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUsers;
using Ambev.DeveloperEvaluation.Application.Users.GetUsers;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users;

/// <summary>
/// Controller for managing user operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
   private readonly IMediator _mediator;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of UsersController
   /// </summary>
   /// <param name="provider">The service provider instance</param>
   public UsersController(IServiceProvider provider)
   {
      _mediator = provider.GetRequiredService<IMediator>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Retrieves a user by their ID
   /// </summary>
   /// <param name="id">The unique identifier of the user</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The user details if found</returns>
   [HttpGet("{id}")]
   [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetUser([FromRoute] int id, CancellationToken cancellationToken)
   {
      var request = new GetUserRequest { Id = id };
      var validator = new GetUserRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var query = _mapper.Map<GetUserQuery>(request.Id);
      var result = await _mediator.Send(query, cancellationToken);

      return Ok(new ApiResponseWithData<GetUserResponse>
      {
         Success = true,
         Message = "User retrieved successfully",
         Data = _mapper.Map<GetUserResponse>(result)
      });
   }

   /// <summary>
   /// Retrieves user by filter
   /// </summary>
   /// <param name="filter">Query filter for user</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The User details if found</returns>
   [HttpGet()]
   [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
   public async Task<IActionResult> GetUsers([FromQuery] QueryFilter filter, CancellationToken cancellationToken)
   {
      var request = new GetUsersRequest(filter);
      var query = _mapper.Map<GetUsersQuery>(request);
      var result = await _mediator.Send(query, cancellationToken);
      var response = _mapper.Map<PageList<GetUsersResponse>>(result);

      return OkPaginated(response);
   }

   /// <summary>
   /// Creates a new user
   /// </summary>
   /// <param name="request">The user creation request</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created user details</returns>
   [HttpPost]
   [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
   {
      var validator = new CreateUserRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<CreateUserCommand>(request);
      var response = await _mediator.Send(command, cancellationToken);

      return Created(string.Empty, new ApiResponseWithData<CreateUserResponse>
      {
         Success = true,
         Message = "User created successfully",
         Data = _mapper.Map<CreateUserResponse>(response)
      });
   }

   /// <summary>
   /// Updates a user
   /// </summary>
   /// <param name="request">The user update request</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated user details</returns>
   [HttpPut("{id}")]
   [ProducesResponseType(typeof(ApiResponseWithData<UpdateUserResponse>), StatusCodes.Status200OK)]
   [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
   public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
   {
      var validator = new UpdateUserRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<UpdateUserCommand>(request);
      command.Id = id; // Ensure the ID is set for the command

      var response = await _mediator.Send(command, cancellationToken);

      return Ok(new ApiResponseWithData<UpdateUserResponse>
      {
         Success = true,
         Message = "User updated successfully",
         Data = _mapper.Map<UpdateUserResponse>(response)
      });
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
      var request = new DeleteUserRequest { Id = id };
      var validator = new DeleteUserRequestValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         return BadRequest(validationResult.Errors);

      var command = _mapper.Map<DeleteUserCommand>(request.Id);
      var result = await _mediator.Send(command, cancellationToken);
      var response = _mapper.Map<DeleteUserResponse>(result);

      return Ok(response, true);
   }
}
