using Xunit;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Features.Users;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using FluentAssertions;
using NSubstitute;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUsers;
using Ambev.DeveloperEvaluation.Application.Users.GetUsers;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;

public class UsersControllerTests
{
   private readonly IMediator _mediator = Substitute.For<IMediator>();
   private readonly IMapper _mapper = Substitute.For<IMapper>();
   private readonly UsersController _controller;

   public UsersControllerTests() => _controller = new UsersController(_mediator, _mapper);

   [Fact(Skip = "Should a valid request return user with success")]
   public async Task GetUser_ReturnsOk_WhenUserExists()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request return all users with success")]
   public async Task GetAllUsers_ReturnsOk_WhenUserExists()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request create an user with success")]
   public async Task CreateUser_ReturnsOk_WhenUserExists()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request update an user with success")]
   public async Task Updateser_ReturnsOk_WhenUserExists()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request delete an unser with success")]
   public async Task DeleteUser_ReturnsOk_WhenUserExists()
   {
      // TODO: implement....
   }

   // TODO: CreateUser, UpdateUser, DeleteUser
}
