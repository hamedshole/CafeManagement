using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    internal class CafeDataUnit(CafeContext context) : ICafeDataUnit
    {
        private readonly ISql _sqlRepository = new SqlRepository(context.Database.GetConnectionString() ?? throw new Exception());

        private readonly CafeContext _context = context;
        private readonly IRepository<TableEntity>? _tableRepository = null;
        private readonly IRepository<MaterialEntity>? _materialRepository = null;
        private readonly IRepository<UnitEntity>? _unitRepository = null;
        private readonly IRepository<AdditiveEntity>? _additiveRepository = null;
        private readonly IRepository<ProductCategoryEntity>? _productCategoryRepository = null;
        private readonly IRepository<ProductEntity>? _productRepository = null;
        private readonly IRepository<ProductAdditiveEntity>? _productAdditiveRepository = null;
        private readonly IRepository<ProductMaterialEntity>? _productMaterialRepository = null;
        private readonly IRepository<ProductPriceLogEntity>? _productPriceLogRepository = null;
        private readonly IRepository<MaterialPriceLogEntity>? _materialPriceLogrepository = null;
        private readonly IRepository<AdditivePriceLogEntity>? _additivePriceLogRepository = null;
        private readonly IRepository<CustomerEntity>? _customerRepository;
        private readonly IRepository<InventoryEntity>? _inventoriyRepository;
        private readonly IRepository<InventoryLogEntity>? _inventoryLogrepository;
        private readonly IRepository<OrderEntity>? _orderRepository;
        private readonly IRepository<OrderItemEntity>? _orderItemRepository;
        private readonly IRepository<OrderItemAdditiveEntity>? _orderItemAdditiveRepository;
        private readonly IRepository<UserEntity>? _userRepository;
        private readonly IRepository<InventoryFactorEntity> _inventoryFactorsRepository;

        public ISql Sql => _sqlRepository;

        public IRepository<TableEntity> Tables => _tableRepository ?? new DataRepository<TableEntity>(_context, this);
        public IRepository<MaterialEntity> Materials => _materialRepository ?? new DataRepository<MaterialEntity>(_context, this);
        public IRepository<UnitEntity> Units => _unitRepository ?? new DataRepository<UnitEntity>(_context, this);
        public IRepository<AdditiveEntity> Additives => _additiveRepository ?? new DataRepository<AdditiveEntity>(_context, this);
        public IRepository<ProductCategoryEntity> Categories => _productCategoryRepository ?? new DataRepository<ProductCategoryEntity>(_context, this);
        public IRepository<ProductEntity> Products => _productRepository ?? new DataRepository<ProductEntity>(_context, this);
        public IRepository<ProductAdditiveEntity> ProductAdditives => _productAdditiveRepository ?? new DataRepository<ProductAdditiveEntity>(_context, this);
        public IRepository<ProductMaterialEntity> ProductMaterials => _productMaterialRepository ?? new DataRepository<ProductMaterialEntity>(_context, this);
        public IRepository<ProductPriceLogEntity> ProductPriceLogs => _productPriceLogRepository ?? new DataRepository<ProductPriceLogEntity>(_context, this);
        public IRepository<MaterialPriceLogEntity> MaterialPriceLogs => _materialPriceLogrepository ?? new DataRepository<MaterialPriceLogEntity>(_context, this);
        public IRepository<AdditivePriceLogEntity> AdditivePriceLogs => _additivePriceLogRepository ?? new DataRepository<AdditivePriceLogEntity>(_context, this);
        public IRepository<CustomerEntity> Customers=>_customerRepository??new DataRepository<CustomerEntity>(_context, this);
        public IRepository<InventoryEntity> Inventories=>_inventoriyRepository??new DataRepository<InventoryEntity>(_context, this);
        public IRepository<InventoryLogEntity> InventoryLogs=>_inventoryLogrepository??new DataRepository<InventoryLogEntity>(_context, this);
        public IRepository<OrderEntity> Orders=>_orderRepository??new DataRepository<OrderEntity>(_context, this);
        public IRepository<OrderItemEntity> OrderItems=>_orderItemRepository??new DataRepository<OrderItemEntity>(_context, this);
        public IRepository<OrderItemAdditiveEntity> OrderItemAdditives=>_orderItemAdditiveRepository??new DataRepository<OrderItemAdditiveEntity>(_context, this);
        public IRepository<UserEntity> Users=>_userRepository??new DataRepository<UserEntity>(_context, this);
        public IRepository<InventoryFactorEntity> InventoryFactors=>_inventoryFactorsRepository??new    DataRepository<InventoryFactorEntity>(_context, this);  

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var t = await _context.SaveChangesAsync(cancellationToken);
            var tt = _context.Tables.Count();
        }
    }
}
