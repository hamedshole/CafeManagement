using MudBlazor;
using Shared.Model;
using WebApp.Util;
namespace WebApp.Components.Pages.Category
{
    public partial class CategoryList
    {
        private CategoryDetail _panel;
        private async Task<GridData<ProductCategoryModel>> LoadData(GridState<ProductCategoryModel> gridState)
        {
            var res = await _restUnit.Category.GetPagedList<ProductCategoryModel>(gridState.GetParameterString());
            if (res.Items is null)
                res = new PagedList<ProductCategoryModel>(new List<ProductCategoryModel>(), res.TotalItems);
            return new GridData<ProductCategoryModel> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(int id)
        {
            await _restUnit.Category.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
    }

}
