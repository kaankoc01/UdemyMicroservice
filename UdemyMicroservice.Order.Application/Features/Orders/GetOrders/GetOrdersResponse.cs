using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMicroservice.Order.Application.Features.Orders.Create;

namespace UdemyMicroservice.Order.Application.Features.Orders.GetOrders
{
    public record GetOrdersResponse(DateTime Created,decimal TotalPrice, List<OrderItemDto> Items);

}
