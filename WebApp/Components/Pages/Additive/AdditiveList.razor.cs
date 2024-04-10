using MudBlazor;
using Shared.Model;
using WebApp.Util;

namespace WebApp.Components.Pages.Additive
{
    public partial class AdditiveList
    {
        private AdditiveDetail _panel;
        private async Task<GridData<AdditiveModel>> LoadData(GridState<AdditiveModel> gridState)
        {
            var res = await _restUnit.Additive.GetPagedList<AdditiveModel>(gridState.GetParameterString());
            if (res.Items is null)
                res = new PagedList<AdditiveModel>(new List<AdditiveModel>(), res.TotalItems);
            return new GridData<AdditiveModel> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(int id)
        {
            await _restUnit.Additive.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
    }
}
