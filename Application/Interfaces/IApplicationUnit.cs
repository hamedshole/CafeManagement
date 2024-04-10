namespace Application.Interfaces
{
    public interface IApplicationUnit
    {
        ITableService Tables { get; }
        IMaterialService Materials { get; }
        IUnitService Units { get; }
        IAdditiveService Additives { get; }
        IProductCategoryService Categories { get; }
        IProductService Products { get; }
        IUserService Users { get; }
        ICustomerService Customers { get; }
        IOrderService Orders { get; }
        IInventoryService Inventories { get; }
        IFactorService Factors { get; }
    }
}
