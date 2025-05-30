using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProductCategories;

/// <summary>
/// Query for retrieving all product categories 
/// </summary>
public class GetProductCategoriesQuery : IRequest<string[]>
{
}
