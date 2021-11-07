using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umschlag_Backend.Core;

namespace Umschlag_Backend.Data.Seed
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pen", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Pencil", Price = 40.50m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Small Notebook", Price = 50.50m, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 4, Name = "Medium Notebook", Price = 50.50m, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Big Notebook", Price = 50.50m, Stock = 100, CategoryId = _ids[1] }
            );
        }
    }
}