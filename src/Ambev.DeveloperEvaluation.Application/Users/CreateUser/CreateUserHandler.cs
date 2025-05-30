using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="provider">The service provider</param>
    public CreateUserHandler(IServiceProvider provider)
    {
        _mapper = provider.GetRequiredService<IMapper>();
        _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
        _passwordHasher = provider.GetRequiredService<IPasswordHasher>();
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingUser = await _unitOfWork.Users.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null) throw new InvalidOperationException($"This email {command.Email} already exists");

        var user = _mapper.Map<User>(command);
        user.Password = _passwordHasher.HashPassword(command.Password);
        var createdUser = await _unitOfWork.Users.CreateAsync(user, cancellationToken);
        var result = _mapper.Map<CreateUserResult>(createdUser);
        return result;
    }
}
