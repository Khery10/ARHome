using ARHome.Application.Mapper;
using ARHome.Application.Models.Base;
using ARHome.Core.Entities.Base;
using ARHome.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHome.Application.Interfaces.Base
{
    public class ServiceBase<TEntity, TModel> : IService<TModel>
        where TEntity : Entity
        where TModel : BaseModel
    {
        private readonly IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IList<TModel>> GetListAsync()
        {
            var entitiesList = await _repository.ListAllAsync();
            return ObjectMapper.Mapper.Map<IList<TModel>>(entitiesList);
        }

        public async Task<TModel> GetByIdAsync(int entityId)
        {
            var entity = await _repository.GetByIdAsync(entityId);
            return ObjectMapper.Mapper.Map<TModel>(entity);
        }

        public async Task<TModel> CreateAsync(TModel model)
        {
            if (await EntityExistAsync(model.Id))
                throw new ApplicationException($"Entity with this id = {model.Id} already exists");

            var newEntity = ObjectMapper.Mapper.Map<TEntity>(model);
            newEntity = await _repository.SaveAsync(newEntity);

            return ObjectMapper.Mapper.Map<TModel>(newEntity);
        }

        public async Task UpdateAsync(TModel model)
        {
            var existEntity = await _repository.GetByIdAsync(model.Id) ??
                throw new ApplicationException($"Entity with this id = {model.Id} is not exists");

            var updatedEntity = ObjectMapper.Mapper.Map(model, existEntity);
            await _repository.SaveAsync(updatedEntity);
        }

        public async Task DeleteByIdAsync(int entityId)
        {
            var entity = await _repository.GetByIdAsync(entityId) ??
                throw new ApplicationException($"Entity with this id = {entityId} is not exists");

            await _repository.DeleteAsync(entity);
        }

        private async Task<bool> EntityExistAsync(int entityId)
            => await _repository.GetByIdAsync(entityId) != null;

    }
}
