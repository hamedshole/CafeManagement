using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Model;

namespace WebApp.Components.Pages.Category
{
    public partial class CategoryDetail
    {
        private ProductCategoryModel value = new ProductCategoryModel();
        [Parameter]
        public Action CloseAction { get; set; }
        
        private bool IsUpdate=false;

        public void Update(ProductCategoryModel model, Action v)
        {
            IsUpdate=true;
            Title = "ویرایش دسته بندی";
            value=model;
            v.Invoke();
            StateHasChanged();
        }
        private async void UploadFiles(IBrowserFile? browserFile)
        {
            if (browserFile != null)
            {

            value.Image =await ConvertToBase64(browserFile.OpenReadStream(maxAllowedSize:int.MaxValue));
            }
            StateHasChanged();
        }
        private async Task<string> ConvertToBase64(Stream stream)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                byte[] byteArray = ms.ToArray();
                return Convert.ToBase64String(byteArray);
            }

        }
        private async Task Submit()
        {
            if (IsUpdate)
            {
                UpdateProductCategoryParameter parameter = new UpdateProductCategoryParameter
                    (
                    value.Id, value.Order, value.Title, value.IsActive, value.Image, value.Description
                    );
               await _client.Category.UpdateAsync(parameter.Id,parameter);
            }
            else
            {
                CreateProductCategoryParameter parameter = new CreateProductCategoryParameter
                {
                    Description = value.Description,
                    Image = value.Image,
                    IsActive = value.IsActive,
                    Order = value.Order,
                    Title = value.Title
                };
                await _client.Category.CreateAsync(parameter);
            }
                CloseAction.Invoke();
            value = new ProductCategoryModel();
        }
    }
}
