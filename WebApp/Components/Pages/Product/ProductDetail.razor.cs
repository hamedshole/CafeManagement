using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Shared.Model;
using MudBlazor;

namespace WebApp.Components.Pages.Product
{
    public partial class ProductDetail
    {
        private ProductDetailModel value = new ProductDetailModel();
        [Parameter]
        public Action CloseAction { get; set; }

        private bool IsUpdate = false;
        ProductCategoryModel _category;
        private ICollection<MaterialSelectModel> _materials = new List<MaterialSelectModel>();
        private ICollection<AdditiveSelectModel> _additives = new List<AdditiveSelectModel>();
        
        public async Task Update(int id, Action v)
        {
            IsUpdate = true;
            Title = "ویرایش دسته بندی";
            value = await _client.Product.Get<ProductDetailModel>(id);
            if (value.CategoryId != 0)
            {
                _category = await _client.Category.Get<ProductCategoryModel>(value.CategoryId);
            }
            _materials = value.Materials;
            _additives=value.Additives;
            v.Invoke();
            StateHasChanged();
        }
        private async void UploadFiles(IBrowserFile? browserFile)
        {
            if (browserFile != null)
            {

                value.Image = await ConvertToBase64(browserFile.OpenReadStream(maxAllowedSize: int.MaxValue));
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
                UpdateProductParameter parameter = new UpdateProductParameter
                    (
                    value.Id, value.Order, _category.Id, value.Title, value.Image, value.Price, value.Description, value.IsNew, value.IsActive, _materials.Select(x=>new CreateProductMaterialParameter(x.Id,x.Amount)).ToList(), _additives.Select(x=>x.Id).ToList()
                    );
                await _client.Product.UpdateAsync(parameter.Id, parameter);
            }
            else
            {
                CreateProductParameter parameter = new CreateProductParameter
                    (
                        value.Order, _category.Id, value.Title, value.Image, value.Price, value.Description, value.IsNew, value.IsActive, _materials.Select(x => new CreateProductMaterialParameter(x.Id, x.Amount)).ToList(), _additives.Select(x => x.Id).ToList()
                    );

                await _client.Product.CreateAsync(parameter);
            }
            CloseAction.Invoke();
            value = new ProductDetailModel();
        }

        private async Task<IEnumerable<AdditiveModel>> SearchAdditives(string text)
        {
            List<AdditiveModel> res = new List<AdditiveModel>();
            if (!string.IsNullOrEmpty(text))
            {
                var t = await _client.Additive.GetPagedList<AdditiveModel>("?title=" + text);
                res = t.Items.Where(x => !_additives.Select(x => x.Title).ToList().Contains(x.Title)).ToList();
            }
            return res;
        }
        private async Task<IEnumerable<MaterialModel>> SearchMaterials(string text)
        {
            List<MaterialModel> res = new List<MaterialModel>();
            if (!string.IsNullOrEmpty(text))
            {
                var t = await _client.Material.GetPagedList<MaterialModel>("?title=" + text);
                res = t.Items.Where(x => !_materials.Select(x => x.Title).ToList().Contains(x.Title)).ToList();
            }
            return res;
        }
        private string AdditiveToString(AdditiveModel model)
        {
            if (model == null)
                return string.Empty;
            else
                return model.Title;
        }
        private string MaterialToString(MaterialModel model)
        {
            if (model == null)
                return string.Empty;
            else
                return model.Title;
        }
        MudAutocomplete<MaterialModel> _materialSelect;
        MudAutocomplete<AdditiveModel> _additiveSelect;

        private void MaterialChanged(MaterialModel material)
        {
            _materials.Add(new MaterialSelectModel(material.Id, material.Title, material.Unit, 0));
            _materialSelect.Clear();
            StateHasChanged();
        }
        private void AdditiveChanged(AdditiveModel additive)
        {
            _additives.Add(new AdditiveSelectModel(additive.Id, additive.Title));

            _additiveSelect.Clear();
            StateHasChanged();
        }
        private void CancelMaterial(int id)
        {
            _materials.Remove(_materials.First(x => x.Id == id));
            StateHasChanged();
        }
        private void CancelAdditive(int id)
        {
            _additives.Remove(_additives.First(x => x.Id == id));
            StateHasChanged();
        }
        private void AddUpdateMaterialAmount(int id, long amount)
        {
            MaterialSelectModel? materialParameter = _materials.Where(x => x.Id == id).FirstOrDefault();
            if (materialParameter is MaterialSelectModel)
            {
                _materials.First(x => x.Id == id).Amount = amount;
            }
          

        }
        private async Task<IEnumerable<ProductCategoryModel>> SearchCategory(string text)
        {
            var res = await _client.Category.GetPagedList<ProductCategoryModel>($"?Title={text}&Page=1&PageSize=10&IsActive=true");
            return res.Items;
        }
    }
}
