using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Ambev.DeveloperEvaluation.Domain.Values;
using Ambev.DeveloperEvaluation.Domain;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUsers;

/// <summary>
/// Handler for processing GetUsersQuery requests
/// </summary>
public class GetUsersHandler : IRequestHandler<GetUsersQuery, PageList<GetUsersResult>>
{
   private readonly IUnitOfWork _unitOfWork;
   private readonly IMapper _mapper;

   /// <summary>
   /// Initializes a new instance of GetUsersHandler
   /// </summary>
   /// <param name="provider">Service locator for DI</param>
   public GetUsersHandler(IServiceProvider provider)
   {
      _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
      _mapper = provider.GetRequiredService<IMapper>();
   }

   /// <summary>
   /// Handles the GetUsersQuery request
   /// </summary>
   /// <param name="request">The GetUsers query</param>
   /// <param name="cancellationToken">Cancellation token</param>
   /// <returns>The user list if found</returns>
   public async Task<PageList<GetUsersResult>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
   {
      var users = await _unitOfWork.Users.ListAsync(request);
      if (users is null) throw new KeyNotFoundException($"Users not found");

      return _mapper.Map<PageList<GetUsersResult>>(users);
   }
}
