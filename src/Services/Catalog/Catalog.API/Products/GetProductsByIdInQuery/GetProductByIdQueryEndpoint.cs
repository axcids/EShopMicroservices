namespace Catalog.API.Products.GetProductsByIdInQuery; 
//public record GetProductByIdRequest();
public record GetProductByIdResponse(Product product);
public class GetProductByIdQueryEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/GetProductById/{id}", async (Guid id, ISender sender) => {
            var product = await sender.Send(new GetProductByIdQuery(id));
            var response = new GetProductByIdResponse(product.product);
            return Results.Ok(response);
        })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get a product by its ID in query");
    }
}
