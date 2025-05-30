using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Handler for processing GetUserQuery requests
/// </summary>
public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResult>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetUserHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetUserHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the GetUserQuery request
   /// </summary>
   /// <param name="request">The GetUser query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The user details if found</returns>
   public async Task<GetUserResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
   {
      var validator = new GetUserValidator();
      var validationResult = await validator.ValidateAsync(request, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var user = await _unitOfWork.Users.GetAsync(request.Id, cancellationToken);
      if (user == null) throw new KeyNotFoundException($"User with ID {request.Id} not found");

      return _mapper.Map<GetUserResult>(user);
   }
}
