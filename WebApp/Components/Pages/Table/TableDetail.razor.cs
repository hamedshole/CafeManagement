using Microsoft.AspNetCore.Components;
using Shared.Model;

namespace WebApp.Components.Pages.Table
{
    public partial class TableDetail
    {
        private TableModel value = new TableModel();

        [Parameter]
        public Action CloseAction { get; set; }

        private bool IsUpdate = false;

        public async void Update(int id, Action v)
        {
            IsUpdate = true;
            Title = "ویرایش واحد";
            value = await _client.Table.Get<TableModel>(id);
            v.Invoke();
            StateHasChanged();
        }

        private async Task Submit()
        {
            if (IsUpdate)
            {
                UpdateTableParameter parameter = new UpdateTableParameter
                    (
                    value.Id, value.Title, value.IsActive
                    );
                await _client.Table.UpdateAsync(parameter.Id, parameter);
            }
            else
            {
                CreateTableParameter parameter = new CreateTableParameter
                {
                    Title = value.Title,
                    IsActive = value.IsActive,
                  
                };
                await _client.Table.CreateAsync(parameter);
            }
            CloseAction.Invoke();
            value = new TableModel();
        }
    }
}
