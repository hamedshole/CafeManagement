using Microsoft.AspNetCore.Components;
using Shared.Model;

namespace WebApp.Components.Pages.Additive
{
    public partial class AdditiveDetail
    {
        private AdditiveDetailModel value = new AdditiveDetailModel();

        [Parameter]
        public Action CloseAction { get; set; }

        private bool IsUpdate = false;

        public async void Update(int id, Action v)
        {
            IsUpdate = true;
            Title = "ویرایش واحد";
            value = await _client.Additive.Get<AdditiveDetailModel>(id);
            if (value.MaterialId != 0)
            {
                var parent = await _client.Material.Get<MaterialDetailModel>(value.MaterialId);
                _parent = new MaterialModel { Id = parent.Id, Title = parent.Title, IsActive = parent.IsActive, UnitPrice = parent.UnitPrice.ToString("#,#"),Unit=parent.UnitId.ToString() };
            }
            v.Invoke();
            StateHasChanged();
        }

        private async Task Submit()
        {
            if (IsUpdate)
            {
                UpdateAdditiveParameter parameter = new UpdateAdditiveParameter()
                {
                    Id = value.Id,
                    Title = value.Title,
                    IsActive = value.IsActive,
                    Amount = value.Amount,
                    MaterialId = _parent.Id,
                    Price = value.Price
                };
                await _client.Additive.UpdateAsync(parameter.Id, parameter);
            }
            else
            {
                CreateAdditiveParameter parameter = new CreateAdditiveParameter
                {
                    Title = value.Title,
                    IsActive = value.IsActive,
                    Amount = value.Amount,
                    MaterialId = _parent.Id
                };
                await _client.Additive.CreateAsync(parameter);
            }
            CloseAction.Invoke();
            value = new AdditiveDetailModel();
        }
    }
}
