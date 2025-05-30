using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser
{
   public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
   {
      private readonly IUnitOfWork _unitOfWork;
      private readonly IPasswordHasher _passwordHasher;
      private readonly IJwtTokenGenerator _jwtTokenGenerator;

      /// <summary>
      /// Initializes a new instance of AuthenticateUserHandler
      /// </summary>
      /// <param name="provider">Service locator for DI</param>
      public AuthenticateUserHandler(IServiceProvider provider)
      {
         _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
         _passwordHasher = provider.GetRequiredService<IPasswordHasher>();
         _jwtTokenGenerator = provider.GetRequiredService<IJwtTokenGenerator>();
      }

      public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
      {
         var user = await _unitOfWork.Users.GetByEmailAsync(request.Email, cancellationToken);

         if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

         var activeUserSpec = new ActiveUserSpecification();
         if (!activeUserSpec.IsSatisfiedBy(user))
            throw new UnauthorizedAccessException("User is not active");

         var token = _jwtTokenGenerator.GenerateToken(user);

         return new AuthenticateUserResult
         {
            Token = token,
            Email = user.Email,
            Name = user.Username,
            Role = user.Role.ToString()
         };
      }
   }
}
