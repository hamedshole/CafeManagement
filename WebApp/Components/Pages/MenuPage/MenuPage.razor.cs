using Microsoft.JSInterop;
using Shared.Model;

namespace WebApp.Components.Pages.MenuPage
{
    public partial class MenuPage
    {
        
        private IJSObjectReference _module;
        private ICollection<MenuCategoryModel> _menuCategories=new  List<MenuCategoryModel>();
        protected async override Task OnInitializedAsync()
        {
            _menuCategories = await _client.Category.GetMenu();

        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                
                _module = await _js.InvokeAsync<IJSObjectReference>("import", "/Components/Pages/MenuPage/MenuPage.Razor.js");
                await _module.InvokeVoidAsync("InitScrollSpy");
            }
        }
        public async Task GotoSection(string id, string headerid)
        {
            await _module.InvokeVoidAsync("GoToSection", id, headerid);
        }
        public async Task GotoHeader(string headerid)
        {
            await _module.InvokeVoidAsync("GoToHeader", headerid);
        }
        private string GetActiveClass(int i)
        {
            if (i == 0)
                return "swiper-slide NavItem1 swiper-slide swiper-slide-active";
            else
                return "swiper-slide NavItem1 swiper-slide";


        }

        private async Task ShowProduct(int id)
        {
           await _module.InvokeVoidAsync("ShowProduct");
        }
    }
}
