using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umschlag_Backend.Core;

namespace Umschlag_Backend.Data.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id).UseIdentityByDefaultColumn();
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("Categories");
        }
    }
}