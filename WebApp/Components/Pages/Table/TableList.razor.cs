using MudBlazor;
using Shared.Model;
using WebApp.Util;

namespace WebApp.Components.Pages.Table
{
    public partial class TableList
    {
        private TableDetail _panel;
        private async Task<GridData<TableModel>> LoadData(GridState<TableModel> gridState)
        {
            var res = await _restUnit.Table.GetPagedList<TableModel>(gridState.GetParameterString());
            if (res.Items is null)
                res = new PagedList<TableModel>(new List<TableModel>(), res.TotalItems);
            return new GridData<TableModel> { Items = res.Items, TotalItems = res.TotalItems };
        }
        private async Task Delete(int id)
        {
            await _restUnit.Table.DeleteAsync(id);
            await _dataGrid.ReloadServerData();
        }
    }
}
