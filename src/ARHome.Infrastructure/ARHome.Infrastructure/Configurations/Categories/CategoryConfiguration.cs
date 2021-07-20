using ARHome.Core.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARHome.Infrastructure.Configurations.Categories
{
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(v => v.Value, v => new CategoryKey(v));

            builder.Property(e => e.SurfaceType)
                .ValueGeneratedNever()
                .HasConversion(v => v.Code, code => new SurfaceType(code));
        }
    }
}