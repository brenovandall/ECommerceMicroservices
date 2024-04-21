using BuildingBlocks.CQRS;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, List<string> Category, 
    string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required").Length(2, 150).WithMessage("Name must be between 2 and 150 characters");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Product category is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Product description is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Product image file is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Product image file is required").GreaterThan(0).WithMessage("Price needs to be greater than 0");
    }
}

internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler. Handle called with {@Query}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null) throw new ProductNotFoundException(command.Id);

        product.Name = command.Name;
        product.Category = command.Category;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        session.Update(product);
        await session.SaveChangesAsync();

        return new UpdateProductResult(true);
    }
}
