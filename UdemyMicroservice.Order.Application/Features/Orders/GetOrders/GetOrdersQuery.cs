using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMicroservice.Shared;

namespace UdemyMicroservice.Order.Application.Features.Orders.GetOrders
{
    public record GetOrdersQuery :IRequestByServiceResult<List<GetOrdersResponse>>
	{
		
	}

}
