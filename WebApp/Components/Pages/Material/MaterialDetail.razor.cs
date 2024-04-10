using Microsoft.AspNetCore.Components;
using Shared.Model;

namespace WebApp.Components.Pages.Material
{
    public partial class MaterialDetail
    {
        private MaterialDetailModel value = new MaterialDetailModel();

        [Parameter]
        public Action CloseAction { get; set; }

        private bool IsUpdate = false;

        public async void Update(int id, Action v)
        {
            IsUpdate = true;
            Title = "ویرایش واحد";
            value = await _client.Material.Get<MaterialDetailModel>(id);
            if (value.UnitId != 0)
            {
                var parent = await _client.Unit.Get<UnitDetailModel>(value.UnitId);
                _parent = new UnitModel { Id = parent.Id, Title = parent.Title, IsActive = parent.IsActive, Relation = parent.Relation };
            }
            v.Invoke();
            StateHasChanged();
        }

        private async Task Submit()
        {
            if (IsUpdate)
            {
                UpdateMaterialParameter parameter = new UpdateMaterialParameter()
                {
                    Id = value.Id,
                    Title = value.Title,
                    IsActive = value.IsActive,
                    UnitPrice = value.UnitPrice,
                    UnitId = _parent.Id
                };
                await _client.Material.UpdateAsync(parameter.Id, parameter);
            }
            else
            {
                CreateMaterialParameter parameter = new CreateMaterialParameter
                {
                    Title = value.Title,
                    IsActive = value.IsActive,
                    UnitPrice = value.UnitPrice,
                    UnitId = _parent.Id
                };
                await _client.Material.CreateAsync(parameter);
            }
            CloseAction.Invoke();
            value = new MaterialDetailModel();
        }
    }
}
