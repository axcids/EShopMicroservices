using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct; 

public record CreateProductCommand(
        string Name, 
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price
) : ICommand<CreateProductCommandResult>;
public record CreateProductCommandResult(Guid Id);
internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductCommandResult> {
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

        //Return the result of the operation  
        return new CreateProductCommandResult(Guid.NewGuid());
    }
}
