using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Handler for processing UpdateUserCommand requests
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
   private readonly IMapper _mapper;
   private readonly IUnitOfWork _unitOfWork;
   private readonly IPasswordHasher _passwordHasher;

   /// <summary>
   /// Initializes a new instance of UpdateUserHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public UpdateUserHandler(IServiceProvider provider)
   {
      _mapper = provider.GetRequiredService<IMapper>();
      _passwordHasher = provider.GetRequiredService<IPasswordHasher>();
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
   }

   /// <summary>
   /// Handles the UpdateUserCommand request
   /// </summary>
   /// <param name="command">The UpdateUser command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The updated user details</returns>
   public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
   {
      var validator = new UpdateUserCommandValidator();
      var validationResult = await validator.ValidateAsync(command, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var user = _mapper.Map<User>(command);
      user.Password = _passwordHasher.HashPassword(command.Password);

      var updatedUser = await _unitOfWork.Users.UpdateAsync(user, cancellationToken);
      var result = _mapper.Map<UpdateUserResult>(updatedUser);
      return result;
   }
}
