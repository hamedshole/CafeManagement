using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class WriteEntityConfigurations :
        IEntityTypeConfiguration<TableEntity>
        , IEntityTypeConfiguration<UnitEntity>
        , IEntityTypeConfiguration<MaterialEntity>
        , IEntityTypeConfiguration<InventoryLogEntity>
    {



        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<UnitEntity> builder)
        {
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Childs)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            builder.HasOne(x => x.Unit)
                           .WithMany()
                           .HasForeignKey(x => x.UnitId)
                           .OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<InventoryLogEntity> builder)
        {
            builder.HasOne(x => x.Unit)
                            .WithMany()
                            .HasForeignKey(x => x.UnitId)
                            .OnDelete(DeleteBehavior.NoAction);
        }
       
    }
}
