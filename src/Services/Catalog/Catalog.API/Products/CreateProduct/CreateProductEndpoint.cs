namespace Catalog.API.Products.CreateProduct;
public record CreateProductRequest(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price
);
public record CreateProductResponse(Guid Id);
public class CreateProductEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) => {
            // Adapt the new variable "command" from request object
            var command = request.Adapt<CreateProductCommand>();
            // Send the command and save the result in a new variable 
            var result = await sender.Send(command);
            // Adapt the new variable "response" from the result object
            var response = result.Adapt<CreateProductResponse>();
            // Return the response object to the client 
            return Results.Created($"/products/{response.Id}", response);
        })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Create a new product")
            .WithDescription("Create a new product in the catalog");
    }
}
