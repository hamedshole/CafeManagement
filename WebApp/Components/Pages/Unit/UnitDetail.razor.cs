using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Model;
using Shared.RestClient.Interfaces;

namespace WebApp.Components.Pages.Unit
{
    public partial class UnitDetail
    {
        private UnitDetailModel value = new UnitDetailModel();

        [Parameter]
        public Action CloseAction { get; set; }

        private bool IsUpdate = false;

        public async void Update(int id, Action v)
        {
            IsUpdate = true;
            Title = "ویرایش واحد";
            value = await _client.Unit.Get<UnitDetailModel>(id);
            if (value.ParentId != 0)
            {
                var parent = await _client.Unit.Get<UnitDetailModel>(value.ParentId);
                _parent = new UnitModel { Id = parent.Id, Title = parent.Title, IsActive = parent.IsActive, Relation = parent.Relation };
            }
            v.Invoke();
            StateHasChanged();
        }

        private async Task Submit()
        {
            if (IsUpdate)
            {
                UpdateUnitParameter parameter = new UpdateUnitParameter
                    (
                    value.Id, value.Title, value.ParentId, value.Relation, value.IsActive
                    );
                await _client.Unit.UpdateAsync(parameter.Id, parameter);
            }
            else
            {
                CreateUnitParameter parameter = new CreateUnitParameter
                {
                    Title = value.Title,
                    IsActive = value.IsActive,
                    Relation = value.Relation,
                    ParentId = _parent.Id
                };
                await _client.Unit.CreateAsync(parameter);
            }
            CloseAction.Invoke();
            value = new UnitDetailModel();
        }
    }

}
