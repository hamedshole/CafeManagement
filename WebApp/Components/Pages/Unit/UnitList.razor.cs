using MudBlazor;
using Shared.Model;
using WebApp.Util;

namespace WebApp.Components.Pages.Unit
{
    public partial class UnitList
    {
        private UnitDetail _panel;
        private async Task<GridData<UnitModel>> LoadData(GridState<UnitModel> gridState)
        {
            var res = await _restUnit.Unit.GetPagedList<UnitModel>(gridState.GetParameterString());
            if (res.Items is null)
                res = new PagedList<UnitModel>(new List<UnitModel>(), res.TotalItems);
            return new GridData<UnitModel> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(int id)
        {
            await _restUnit.Unit.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
    }
}
