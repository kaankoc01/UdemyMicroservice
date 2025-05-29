using Asp.Versioning.Builder;

namespace UdemyMicroservice.Order.API.Endpoints.Orders
{
	public static class OrderEndpoint
	{
		public static void AddOrderGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
		{

			app.MapGroup("api/v{version:apiVersion}/orders").WithTags("Orders")
				.WithApiVersionSet(apiVersionSet)
				.CreateOrderGroupItemEndpoint()
				.GetOrderGroupItemEndpoint();
		}
	}
}
