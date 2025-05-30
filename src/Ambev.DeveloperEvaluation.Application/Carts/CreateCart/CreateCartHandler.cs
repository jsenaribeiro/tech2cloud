using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

/// <summary>
/// Handler for processing CreateCartCommand requests
/// </summary>
public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of CreateCartHandler
   /// </summary>
   /// <param name="provider">The service locator for dependencies</param>
   public CreateCartHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the CreateCartCommand request
   /// </summary>
   /// <param name="command">The CreateCart command</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The created cart details</returns>
   public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
   {
      var validationResult = await new CreateCartCommandValidator()
          .ValidateAsync(command, cancellationToken);

      if (!validationResult.IsValid)
         throw new ValidationException(validationResult.Errors);

      var cart = _mapper.Map<Cart>(command);

      var userIdOfCartIsNotFound = await _unitOfWork.Users
         .CountAsync(x => x.Id == command.UserId, cancellationToken) == 0;

      if (userIdOfCartIsNotFound)
         throw new InvalidOperationException($"User with ID {command.UserId} not found.");

      foreach (var item in command.Products)
      {
         var productIdOfCartIsNotFound = await _unitOfWork.Products
            .CountAsync(x => x.Id == item.ProductId, cancellationToken) == 0;

         if (productIdOfCartIsNotFound)
            throw new InvalidOperationException($"Product with ID {item.ProductId} not found.");
      }

      cart.Date = DateTime.SpecifyKind(cart.Date, DateTimeKind.Utc); // mongoDB stores dates in UTC

      var createdCart = await _unitOfWork.Carts.CreateAsync(cart, cancellationToken);
      var result = _mapper.Map<CreateCartResult>(createdCart);

      return result;
   }
}
