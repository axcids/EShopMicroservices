
namespace Catalog.API.Products.GetProducts; 
public record GetProductsQuery : IQuery<GetProductsQueryResult>;
public record GetProductsQueryResult(List<Product> Products);
internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsQueryResult> {
    public Task<GetProductsQueryResult> Handle(GetProductsQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}
