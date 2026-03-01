using MediatR;

namespace Catalog.API.Product.CreateProduct
{
    public record CreateProductCommand(string Name, string Description, decimal Price, List<string> Category, string ImageFile) : IRequest<CreateProductCommandResponse>;
    public record CreateProductCommandResponse(Guid Id);
    internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        public Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
