﻿namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name, 
        List<string> Category,
        string Description, 
        string ImageFile, 
        decimal Price
    ) : ICommand<CreateProducResult>;
    public record CreateProducResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProducResult>
    {
        public async Task<CreateProducResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProducResult(Guid.NewGuid());
        }
    }
}
