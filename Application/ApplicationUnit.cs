using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;

namespace Application
{
    internal class ApplicationUnit(ICafeDataUnit dataUnit, IMapper mapper) : IApplicationUnit
    {
        private readonly ITableService? _tableService;
        private readonly IMaterialService? _materialService;
        private readonly IUnitService? _unitService;
        private readonly IAdditiveService? _additiveService;
        private readonly IProductCategoryService? _productCategoryService;
        private readonly IProductService? _productService;
        private readonly ICustomerService? _customerService;
        private readonly IOrderService? _orderService;
        private readonly IInventoryService? _inventoryService;
        private readonly IFactorService? _factorService;
        private readonly IUserService? _userService;

        public ITableService Tables => _tableService ?? new TableService(dataUnit.Tables, mapper);
        public IMaterialService Materials => _materialService ?? new MaterialService(dataUnit.Materials, mapper);
        public IUnitService Units => _unitService ?? new UnitService(dataUnit.Units, mapper);
        public IAdditiveService Additives=>_additiveService??new AdditiveService(dataUnit.Additives, mapper);
        public IProductCategoryService Categories => _productCategoryService ??new ProductCategoryService(dataUnit.Categories, mapper);
        public IProductService Products=>_productService??new   ProductService(dataUnit.Products, mapper);
        public IUserService Users => _userService ?? new UserService(dataUnit.Users, mapper);
        public ICustomerService Customers=>_customerService??new CustomerService(dataUnit.Customers, mapper);
        public IOrderService Orders=>_orderService??new OrderService(dataUnit.Orders, mapper);
        public IInventoryService Inventories=>_inventoryService??new InventoryService(dataUnit.Inventories, mapper);

        public IFactorService Factors => _factorService??new FactorService(dataUnit.InventoryFactors, mapper);
    }
}
