using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResult>
{
    private readonly IUserRepository _userRepository;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of DeleteUserHandler
   /// </summary>
   /// <param name="userRepository">The user repository</param>
   /// <param name="validator">The validator for DeleteUserCommand</param>
   public DeleteUserHandler(IServiceProvider provider)
   {
      _userRepository = provider.GetRequiredService<IUserRepository>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the DeleteUserCommand request
   /// </summary>
   /// <param name="request">The DeleteUser command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The result of the delete operation</returns>
   public async Task<DeleteUserResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var deletedUser = await _userRepository.DeleteAsync(request.Id, cancellationToken);
        if (deletedUser is null) throw new KeyNotFoundException($"User with ID {request.Id} not found");

      return _mapper.Map<DeleteUserResult>(deletedUser);
    }
}
