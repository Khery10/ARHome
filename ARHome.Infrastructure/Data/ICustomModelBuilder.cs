using Microsoft.EntityFrameworkCore;

namespace ARHome.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
