namespace Catalog.API.Products.GetProductsByIdInQuery; 
public record GetProductByIdQuery(Guid id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product product);

public class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult> {
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
        // Fetch the database
        var product = await session.LoadAsync<Product>(request.id, cancellationToken);
        // Check if product is null
        if ( product is null) {
            throw new ProductNotFoundException();
        }
        // Return the product
        return new GetProductByIdResult(product);
    }
}
