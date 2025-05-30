using Xunit;
using MediatR;
using AutoMapper;
using NSubstitute;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Features.Products;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;

public class ProductsControllerTests
{
   private readonly IMediator _mediator = Substitute.For<IMediator>();
   private readonly IMapper _mapper = Substitute.For<IMapper>();
   private readonly ProductsController _controller;

   public ProductsControllerTests() => _controller = new ProductsController(_mediator, _mapper);

   [Fact(Skip = "Should a valid request return product with success")]
   public async Task GetProduct_ReturnsOk_WhenProductExists()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request return all products with success")]
   public async Task GetAllProducts_ReturnsOk_WhenProductExists()
   {
      // TODO: implement....
   }


   [Fact(Skip = "Should a valid request create a product with success")]
   public async Task CreateProduct_ReturnsOk_WhenIsValid()
   {
      // TODO: implement....
   }


   [Fact(Skip = "Should a valid request update a product with success")]
   public async Task UpdateProduct_ReturnsOk_WhenIsValid()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request delete a product with success")]
   public async Task DeleteProduct_ReturnsOk_WhenIsValid()
   {
      // TODO: implement....
   }

   [Fact(Skip = "Should a valid request get all product categories with success")]
   public async Task GetProductCategories_ReturnsOk_WhenIsValid()
   {
      // TODO: implement....
   }
}
