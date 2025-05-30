using Xunit;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using NSubstitute;
using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using FluentAssertions;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;

public class AuthControllerTests
{
   private readonly IMediator _mediator = Substitute.For<IMediator>();
   private readonly IMapper _mapper = Substitute.For<IMapper>();
   private readonly AuthController _controller;

   public AuthControllerTests() => _controller = new AuthController(_mediator, _mapper);

   [Fact(Skip = "Should a valid request authenticate the user")]
   public async Task AuthenticateUser_ReturnsOk_WhenCredentialsAreValid()
   {
      // TODO: implement....
   }
}
