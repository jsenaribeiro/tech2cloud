using Bogus;
using MediatR;
using Xunit;
using AutoMapper;
using NSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.Domain.Values;
using NSubstitute.ExceptionExtensions;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;

public class CartsControllerTests : AbstractTests
{
   private readonly CartsController _controller;

   public CartsControllerTests() => _controller = new CartsController(provider);

   [Fact(Skip = "Should a valid request get a cart with success")]
   public async Task GetCart_ReturnsOk_WhenCartExists()
   {
      var faker = new Faker();
      var id = faker.Random.Int(1);
      var request = new GetCartRequest(id);
      var response = new GetCartResponse();

      // TODO: implement....

   }

   [Fact(Skip = "Should a invalid request throws a failure")]
   public async Task GetCart_ReturnsNotFound_WhenCartDoesNotExist()
   {
      var faker = new Faker();
      var id = faker.Random.Int(1);
      var request = new GetCartRequest(id);

      // TODO: implement....
   }

   [Fact(Skip = "Should an expected error throws a server error exception")]
   public async Task GetCart_ReturnsServerError_OnException()
   {
      var faker = new Faker();
      var id = faker.Random.Int(1);
      var request = new GetCartRequest(id);

      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request get all carts with success")]
   public async Task GetCarts_ReturnsOkPaginated()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request create a car with success")]
   public async Task CreateCart_ReturnsCreated()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should an invalid request throws a failure")]
   public async Task CreateCart_ReturnsBadRequest_OnValidationFailure()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a mediator exception throws a server error 500")]
   public async Task CreateCart_ReturnsStatus500_OnMediatorException()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request update a car with success")]
   public async Task UpdateCart_ReturnsOk()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a not existent car throw a not found exception")]
   public async Task UpdateCart_ReturnsNotFound_WhenCartDoesNotExist()
   {
      // TODO: implement....
   }


   [Fact(Skip = "Should a valid request deletes an user with success")]
   public async Task DeleteUser_ReturnsOk()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Sould a not existent user throws a not found error when trying delete the user")]
   public async Task DeleteUser_ReturnsNotFound_WhenCartDoesNotExist()
   {
      // TODO: implement....
   }
}
