using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class ReadEntityConfigurations :

        IEntityTypeConfiguration<TableEntity>
        , IEntityTypeConfiguration<UnitEntity>
        , IEntityTypeConfiguration<MaterialEntity>
        , IEntityTypeConfiguration<AdditiveEntity>
        , IEntityTypeConfiguration<ProductCategoryEntity>
        , IEntityTypeConfiguration<ProductEntity>
        , IEntityTypeConfiguration<ProductMaterialEntity>
        , IEntityTypeConfiguration<ProductPriceLogEntity>
        , IEntityTypeConfiguration<AdditivePriceLogEntity>
        , IEntityTypeConfiguration<MaterialPriceLogEntity>
        , IEntityTypeConfiguration<OrderEntity>
        , IEntityTypeConfiguration<OrderItemEntity>
        , IEntityTypeConfiguration<OrderItemAdditiveEntity>
        , IEntityTypeConfiguration<UserEntity>
        , IEntityTypeConfiguration<CustomerEntity>
        , IEntityTypeConfiguration<InventoryEntity>
        , IEntityTypeConfiguration<InventoryLogEntity>
        , IEntityTypeConfiguration<UserRoleEntity>
        , IEntityTypeConfiguration<RoleEntity>
        , IEntityTypeConfiguration<InventoryFactorEntity>
       
    {


        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.HasData(new TableEntity(1, "1", true), new TableEntity(2, "1", true));
            builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<UnitEntity> builder)
        {
            builder.HasData(new UnitEntity(1, null, "گرم", null));
            builder.HasData(new UnitEntity(2, 1, "کیلوگرم", 1000));
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.Parent).WithMany(x => x.Childs).HasForeignKey(x => x.ParentId);
        }

        public void Configure(EntityTypeBuilder<MaterialEntity> builder)
        {
            MaterialEntity materialEntity = new MaterialEntity(id:1,unitPrice:1000,title: "mater",unitId: 1,isActive: true);
            MaterialEntity materialEntity2 = new MaterialEntity(id:2,title: "mater",unitId: 1,unitPrice:2000,isActive: true);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(materialEntity, materialEntity2);
            builder.Property(x => x.UnitPrice).HasConversion(x => x.Value, x => new Money(x));
        }

        public void Configure(EntityTypeBuilder<AdditiveEntity> builder)
        {
            builder.Property(x => x.Price).HasConversion(x => x.Value, convertFromProviderExpression: x => new Money(x));
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Amount).HasConversion(x => x.Value, x => new Amount(x));
            AdditiveEntity additiveEntity = new AdditiveEntity(1, "ادویه", 1, 100, 10000, true);
            AdditiveEntity additiveEntity2 = new AdditiveEntity(2, "ادویه", 2, 100, 10000, true);
            builder.HasData(additiveEntity, additiveEntity2);
        }

        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            ProductCategoryEntity productCategoryEntity = new ProductCategoryEntity(1, 1, "pc1", "t", true, "gg");
            ProductCategoryEntity productCategoryEntity2 = new ProductCategoryEntity(2, 2, "pc2", "t", true, "gg");
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.HasData(productCategoryEntity, productCategoryEntity2);
        }

        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            ProductEntity productEntity = new ProductEntity(1, 1, 1, "p1", "desc1", "f", true, 10000, true);
            ProductEntity productEntity2 = new ProductEntity(2, 1, 1, "p2", "desc2", "f", true, 20000, false);
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(productEntity, productEntity2);
            builder.Property(x => x.Price).HasConversion(x => x.Value, x => new Money(x));
            //builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<ProductMaterialEntity> builder)
        {
            builder.Property(x => x.Amount).HasConversion(x => x.Value, x => new Amount(x));
            builder.HasQueryFilter(x => !x.IsDeleted);
        }

        public void Configure(EntityTypeBuilder<ProductPriceLogEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Price).HasConversion(x => x.Value, x => new Money(x));
        }

        public void Configure(EntityTypeBuilder<AdditivePriceLogEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Price).HasConversion(x => x.Value, x => new Money(x));
        }

        public void Configure(EntityTypeBuilder<MaterialPriceLogEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.BuyPrice).HasConversion(x => x.Value, convertFromProviderExpression: x => new Money(x));
            builder.Property(x => x.SellPrice).HasConversion(x => x.Value, convertFromProviderExpression: x => new Money(x));

        }

        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.State).HasConversion(x => x.Value, convertFromProviderExpression: x => new OrderState(x));
            builder.Property(x => x.TotalPrice).HasConversion(x => x.Value, convertFromProviderExpression: x => new Money(x));

        }

        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<OrderItemAdditiveEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(propertyExpression: x => x.Gender).HasConversion(x => x.Value, convertFromProviderExpression: x => new Gender(x));
            builder.HasQueryFilter(x => !x.IsDeleted);

        }

        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(new CustomerEntity(1, "1", 1, "hamed", "shole", DateTime.Now, "09147837342"), new CustomerEntity(2, "1", 1, null, "hshk", DateTime.Now, "09147837342"));
            builder.Property(propertyExpression: x => x.Gender).HasConversion(x => x.Value, convertFromProviderExpression: x => new Gender(x));
        }

        public void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasData(new InventoryEntity(1, "انبار یک", true), new InventoryEntity(2, "انبار دو", true));
        }

        public void Configure(EntityTypeBuilder<InventoryLogEntity> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(propertyExpression: x => x.InOut).HasConversion(x => x.Io, convertFromProviderExpression: x => new InOutState(x));
            builder.Property(propertyExpression: x => x.Amount).HasConversion(x => x.Value, convertFromProviderExpression: x => new Amount(x));

        }

        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
        }

        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
        }

        public void Configure(EntityTypeBuilder<InventoryFactorEntity> builder)
        {
            builder.Property(x => x.TotalPrice).HasConversion(x => x.Value, x => new Money(x));
        }
    }
}
