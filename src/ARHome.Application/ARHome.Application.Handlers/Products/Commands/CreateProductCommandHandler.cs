﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Products.Commands.CreateProduct;
using ARHome.Core.Categories;
using ARHome.Core.Products;
using ARHome.DataAccess;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.ImageStorage;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Products.Commands
{
    internal sealed class CreateProductCommandHandler : CommandHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;
        private readonly ProductFactory _factory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorage _imageStorage;

        public CreateProductCommandHandler(
            IProductRepository repository,
            ProductFactory factory,
            IUnitOfWork unitOfWork,
            IImageStorage imageStorage)
        {
            _repository = repository;
            _factory = factory;
            _unitOfWork = unitOfWork;
            _imageStorage = imageStorage;
        }

        public override async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = CreateProduct(command);

            await _repository.AddAsync(product, cancellationToken);
            
            await _imageStorage.UploadImageAsync(
                command.ImageUrl, 
                nameof(Product),
                product.Id.Value,
                cancellationToken);
            
            await _unitOfWork.SaveAsync(cancellationToken);
            return product.Id.Value;
        }

        private Product CreateProduct(CreateProductCommand command)
        {
            return _factory.Create(
                command.Name,
                command.Description,
                new CategoryKey(command.CategoryId));
        }
    }
}