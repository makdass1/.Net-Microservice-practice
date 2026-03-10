using BuildingBlocks.CQRS;
namespace Catalog.API.Product.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, List<string> Category, string ImageFile)
        : ICommand<CreateProductCommandResult>;
    public record CreateProductCommandResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    internal class CreateProductHandler : ICommandHandler <CreateProductCommand, CreateProductCommandResult>
    {
        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Models.Products
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
