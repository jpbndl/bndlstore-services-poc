namespace CatalogAPI.Products.UpdateProduct
{
    public record UpdateProductCommandRequest(
        Guid Id,
        string Name, 
        List<string> Category, 
        string Description, 
        string ImageFile, 
        decimal Price
    ) : ICommand<UpdateProductResponse>;
    public record UpdateProductResponse(Product Product);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductCommandRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
