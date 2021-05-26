using System.Collections.Generic;
using MediatR;

namespace Ordering.Application.Features.Queries.GetOrderList
{
    public class GetOrderListQuery:IRequest<List<OrderDto>>
    {
        public string UserName { get; set; }
    }
}