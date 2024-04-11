using MudBlazor;
using Shared.Model;
using WebApp.Util;

namespace WebApp.Components.Pages.Product
{
    public partial class ProductList
    {
        private ProductDetail _panel;
        private async Task<GridData<ProductModel>> LoadData(GridState<ProductModel> gridState)
        {
            var res = await _restUnit.Product.GetPagedList<ProductModel>(gridState.GetParameterString());
            if (res.Items is null)
                res = new PagedList<ProductModel>(new List<ProductModel>(), res.TotalItems);
            return new GridData<ProductModel> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(int id)
        {
            await _restUnit.Product.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
        private string? GetNewIcon(bool isnew)
        {
            if (isnew)
                return Icons.Material.Filled.NewReleases;
            else
                return string.Empty;
        }
    }
}
