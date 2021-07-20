using System;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Categories.Commands.CreateCategory;
using ARHome.Core.Categories;
using ARHome.DataAccess;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.ImageStorage;
using ARHome.Infrastructure.Abstractions.Repositories;

namespace ARHome.Application.Handlers.Categories.Commands
{
    internal sealed class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository;
        private readonly CategoryFactory _factory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageStorage _imageStorage;

        public CreateCategoryCommandHandler(
            ICategoryRepository repository,
            CategoryFactory factory,
            IUnitOfWork unitOfWork,
            IImageStorage imageStorage)
        {
            _repository = repository;
            _factory = factory;
            _unitOfWork = unitOfWork;
            _imageStorage = imageStorage;
        }

        public override async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = CreateCategory(command);

            await _repository.AddAsync(category, cancellationToken);
            await _imageStorage.UploadImageAsync(
                command.ImageUrl,
                nameof(Category),
                category.Id.Value,
                cancellationToken);

            await _unitOfWork.SaveAsync(cancellationToken);
            return category.Id.Value;
        }

        private Category CreateCategory(CreateCategoryCommand command)
        {
            var surfaceCode = Enum.Parse<SurfaceTypeCode>(command.SurfaceType, true);
            
            return _factory.Create(
                command.Name,
                command.Description,
                new SurfaceType(surfaceCode));
        }
    }
}