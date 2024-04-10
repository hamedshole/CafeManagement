using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Contexts
{
    public class CafeContext : DbContext
    {

        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<MaterialEntity> Materials { get; set; }
        public DbSet<UnitEntity> Units { get; set; }
        public DbSet<AdditiveEntity> Additives { get; set; }
        public DbSet<ProductCategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductMaterialEntity> ProductMaterials { get; set; }
        public DbSet<ProductAdditiveEntity> ProductAdditives { get; set; }
        public DbSet<ProductPriceLogEntity> ProductPriceLogs { get; set; }
        public DbSet<MaterialPriceLogEntity> MaterialPriceLogs { get; set; }
        public DbSet<AdditivePriceLogEntity> AdditivePriceLogs { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
        public DbSet<InventoryLogEntity> InventoryLogs { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<OrderItemAdditiveEntity> OrderItemAdditives { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<InventoryFactorEntity> InventoryFactors { get; set; }

        public CafeContext()
        {

        }

        public CafeContext(DbContextOptions<CafeContext> options) : base(options)
        {
            this.Database.EnsureCreated();
     


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer("Server=.;Database=CmsDb;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=sa;Password=H@med24121373;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyReadConfigurations(modelBuilder);
            ApplyWriteConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void ApplyWriteConfigurations(ModelBuilder modelBuilder)
        {
            WriteEntityConfigurations writeEntityConfigurations = new();
            modelBuilder.ApplyConfiguration<TableEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<UnitEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<MaterialEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<InventoryLogEntity>(writeEntityConfigurations);

        }
        private static void ApplyReadConfigurations(ModelBuilder modelBuilder)
        {
            ReadEntityConfigurations writeEntityConfigurations = new();
            modelBuilder.ApplyConfiguration<UnitEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<TableEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<MaterialEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<AdditiveEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<ProductCategoryEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<ProductEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<ProductMaterialEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<MaterialPriceLogEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<AdditivePriceLogEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<ProductPriceLogEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<CustomerEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<UserEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<RoleEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<InventoryEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<UserRoleEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<InventoryFactorEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<InventoryLogEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<OrderEntity>(writeEntityConfigurations);
            modelBuilder.ApplyConfiguration<OrderItemEntity>(writeEntityConfigurations);



        }
    }
}
