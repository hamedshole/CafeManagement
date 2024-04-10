using Shared.RestClient.Interfaces;
using Shared.RestClient.Repositories;

namespace Shared.RestClient
{
    internal class RestUnit(HttpClient httpClient, INotification notification) : IRestUnit
    {
        private readonly ICategoryClient? _categoryClient;
        private readonly IProductClient? _productClient;
        private readonly ITableClient? _tableRepository;
        private readonly IMaterialClient? _materialCLient;
        private readonly IInventoryClient? _inventoryClient;
        private readonly IAdditiveClient? _additiveClient;
        private readonly IUnitClient? _unitClient;
        ICategoryClient IRestUnit.Category => _categoryClient ?? new CategoryClient(httpClient, "productcategories", notification);

        IProductClient IRestUnit.Product => _productClient ?? new ProductClient(httpClient, "products", notification);

        ITableClient IRestUnit.Table => _tableRepository ?? new TableClient(httpClient, "tables", notification);

        IMaterialClient IRestUnit.Material => _materialCLient ?? new MaterialClient(httpClient, "materials", notification);

        IInventoryClient IRestUnit.Inventory => _inventoryClient ?? new InventoryClient(httpClient, "inventories", notification);

        IAdditiveClient IRestUnit.Additive => _additiveClient ?? new AdditiveClient(httpClient, "additives", notification);
        IUnitClient IRestUnit.Unit => _unitClient ?? new UnitClient(httpClient, "units", notification);
    }
}
