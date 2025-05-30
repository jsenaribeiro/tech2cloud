using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Auth;

/// <summary>
/// Controller for authentication operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="provider">Service provider for dependency injection</param>
    public AuthController(IServiceProvider provider)
    {
        _mediator = provider.GetRequiredService<IMediator>();
        _mapper = provider.GetRequiredService<IMapper>();
    }

    /// <summary>
    /// Authenticates a user with their credentials
    /// </summary>
    /// <param name="request">The authentication request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Authentication token if successful</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<AuthenticateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new AuthenticateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AuthenticateUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new { token = response.Token }, true);
    }
}
