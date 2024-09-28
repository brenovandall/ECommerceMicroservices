﻿
using Microsoft.EntityFrameworkCore;
using BuildingBlocks.Pagination;
using Application.Extensions;

namespace Application.Orders.Queries.GetOrders;

public class GetOrdersHandler (IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;
        var count = await dbContext.Orders.LongCountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetOrdersResult(
            new PaginationResult<OrderDto>(
                pageIndex, 
                pageSize, 
                count, 
                orders.ToOrderDtoList()
                )
            );
    }
}
