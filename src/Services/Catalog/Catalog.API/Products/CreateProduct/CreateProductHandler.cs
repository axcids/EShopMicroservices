namespace Catalog.API.Products.CreateProduct; 

public record CreateProductCommand(
        string Name, 
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price
) : ICommand<CreateProductCommandResult>;
public record CreateProductCommandResult(Guid Id);
internal class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductCommandResult> {
    public async Task<CreateProductCommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken) {

        //Create product entity from command incoming object   
        var product = new Product {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        //  TODO : Save product entity to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //Return the result of the operation  
        return new CreateProductCommandResult(product.Id);
    }
}
