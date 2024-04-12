using Microsoft.JSInterop;

namespace WebApp.Components.Layout
{
    public partial class FooterTabs
    {
        IJSObjectReference _module;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            _module = await _js.InvokeAsync<IJSObjectReference>("import", "/Components/Layout/FooterTabs.Razor.js");
        }
        public async Task Menu(string id)
        {
            await _module.InvokeVoidAsync("MakeActive", id);
        }
        public async Task Profile(string id)
        {
            await _module.InvokeVoidAsync("MakeActive", id);

        }
        public async Task Comments(string id)
        {

        }
    }
}
