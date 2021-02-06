using ARHome.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHome.Application.Interfaces.Base
{
    public interface IService<TModel>
        where TModel : BaseModel
    {
        Task<IList<TModel>> GetListAsync();

        Task<TModel> GetByIdAsync(int entityId);

        Task<TModel> CreateAsync(TModel model);

        Task UpdateAsync(TModel model);

        Task DeleteByIdAsync(int entityId);
    }
}
