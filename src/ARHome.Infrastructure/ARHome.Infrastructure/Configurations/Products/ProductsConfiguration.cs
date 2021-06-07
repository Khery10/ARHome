using ARHome.Core.Categories;
using ARHome.Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ARHome.Infrastructure.Configurations.Products
{
    internal sealed class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasConversion(v => v.Value, v => new ProductKey(v));
            
            builder.Property(e => e.CategoryId)
                .HasConversion(v => v.Value, v => new CategoryKey(v))
                .HasColumnName("Category_Id")
                .IsRequired();
        }
    }
}