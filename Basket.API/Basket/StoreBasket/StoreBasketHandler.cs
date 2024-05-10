namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Basket) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string username);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand> 
{
    public StoreBasketHandler()
    {
        RuleFor(x => x.Basket).NotNull().WithMessage("Basket can not be null");
        RuleFor(x => x.Basket.Username).NotEmpty().WithMessage("Username is required");
    }
}

public async class StoreBasketHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart basket = command.Basket;

        return new StoreBasketResult("sds");
    }
}
