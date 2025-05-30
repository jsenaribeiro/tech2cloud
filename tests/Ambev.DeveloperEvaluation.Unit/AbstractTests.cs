using Xunit;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth;
using Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;
using NSubstitute;
using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;

public abstract class AbstractTests
{
   public readonly IMapper? mapper;
   public readonly IUnitOfWork? unitOfWork;
   public readonly IPasswordHasher? passwordHasher;
   public readonly IServiceProvider provider;

   protected AbstractTests()
   {
      this.provider = new ServiceCollection()
         .AddSingleton(mapper!)
         .AddSingleton(unitOfWork!)
         .AddSingleton(passwordHasher!)
         .BuildServiceProvider();
   }
}