using Application.Orders.Queries.GetOrdersByName;

namespace API.Endpoints;

//public record GetOrdersByNameRequest(string Name);
public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/name/{name}", async (string name, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByNameQuery(name));

            var response = result.Adapt<GetOrdersByNameResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOrdersByName")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Proccess to get all orders filtered the its name")
        .WithDescription("This endpoint sends a request to return a list of orders filtered by its name.");
    }
}
