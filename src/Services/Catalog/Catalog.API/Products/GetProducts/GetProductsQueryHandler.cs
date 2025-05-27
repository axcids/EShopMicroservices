
namespace Catalog.API.Products.GetProducts; 
public record GetProductsQuery : IQuery<GetProductsQueryResult>;
public record GetProductsQueryResult(List<Product> Products);
internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsQueryResult> {
    public async Task<GetProductsQueryResult> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
        
        var products = await session.Query<Product>().ToListAsync();
        
        return new GetProductsQueryResult(products.ToList());
    }
}
