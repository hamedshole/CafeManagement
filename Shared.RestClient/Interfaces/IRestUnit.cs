namespace Shared.RestClient.Interfaces
{
    public interface IRestUnit
    {
        ICategoryClient Category { get; }
        IProductClient Product { get; }
        ITableClient Table { get; }
        IMaterialClient Material { get; }
        IInventoryClient Inventory { get; }
        IAdditiveClient Additive { get; }
        IUnitClient Unit { get; }
        INotification Notification { get; }
    }
}
