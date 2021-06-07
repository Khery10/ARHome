using System;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Products.Commands.CreateProduct;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.DataAccess;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Products.Commands
{
    internal sealed class CreateProductCommandHandler : CommandHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;
        private readonly ProductFactory _factory;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(
            IProductRepository repository,
            ProductFactory factory,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _factory = factory;
            _unitOfWork = unitOfWork;
        }

        public override async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = CreateProduct(command);

            await _repository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            return product.Id.Value;
        }

        private Product CreateProduct(CreateProductCommand command)
        {
            return _factory.Create(
                command.Name,
                command.Description,
                command.ImageUrl,
                new CategoryKey(command.CategoryId));
        }
    }
}