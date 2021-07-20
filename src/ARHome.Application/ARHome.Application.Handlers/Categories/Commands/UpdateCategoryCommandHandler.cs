using System;
using System.Threading;
using System.Threading.Tasks;
using ARHome.Client.Categories.Commands.UpdateCategory;
using ARHome.Core.Categories;
using ARHome.DataAccess;
using ARHome.GenericSubDomain.MediatR;
using ARHome.Infrastructure.Abstractions.Repositories;
using MediatR;

namespace ARHome.Application.Handlers.Categories.Commands
{
    internal sealed class UpdateCategoryCommandHandler : CommandHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(
            ICategoryRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public override async Task<Unit> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(new CategoryKey(command.Id), cancellationToken);
            ModifyCategory(category, command);

            await _repository.UpdateAsync(category, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);
            
            return Unit.Value;
        }

        public void ModifyCategory(Category category, UpdateCategoryCommand command)
        {
            var surfaceCode = Enum.Parse<SurfaceTypeCode>(command.SurfaceType, true);

            category.Description = command.Description;
            category.SurfaceType = new SurfaceType(surfaceCode);
        }
    }
}