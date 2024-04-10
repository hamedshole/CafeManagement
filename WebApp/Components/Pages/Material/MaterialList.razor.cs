using MudBlazor;
using Shared.Model;
using WebApp.Util;

namespace WebApp.Components.Pages.Material
{
    public partial class MaterialList
    {
        private MaterialDetail _panel;
        private async Task<GridData<MaterialModel>> LoadData(GridState<MaterialModel> gridState)
        {
            var res = await _restUnit.Material.GetPagedList<MaterialModel>(gridState.GetParameterString());
            if (res.Items is null)
                res = new PagedList<MaterialModel>(new List<MaterialModel>(), res.TotalItems);
            return new GridData<MaterialModel> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(int id)
        {
            await _restUnit.Material.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
    }
}
