using BuildingBlocks.CQRS;
using Catalog.API.Models;
namespace Catalog.API.Product.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, List<string> Category, string ImageFile)
        : ICommand<CreateProductCommandResult>;
    public record CreateProductCommandResult(Guid Id);
    internal class CreateProductHandler : ICommandHandler <CreateProductCommand, CreateProductCommandResult>
    {
        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Products
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Category = request.Category,
                ImageFile = request.ImageFile

            };

            return new CreateProductCommandResult(Guid.NewGuid());

        }
    }
}
