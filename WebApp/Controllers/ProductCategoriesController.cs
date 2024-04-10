using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController(IApplicationUnit application) : ControllerBase
    {
        private readonly IProductCategoryService _service = application.Categories;

        // GET: api/<ProductCategorysController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListProductCategoryParameter pagingParameter)
        {
            ProductCategorySpecifications ProductCategorySpecifications = new();
            ProductCategorySpecifications.AddFilters(pagingParameter);
            PagedList<ProductCategoryModel> res = await _service.GetPaged(ProductCategorySpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<ProductCategorysController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<ProductCategorysController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCategoryParameter value)
        {
            try
            {
                await _service.CreateAsync(value);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ProductCategorysController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateProductCategoryParameter value)
        {
            UpdateProductCategoryParameter updateProductCategoryParameter = new(id, value.Order, value.Title, value.IsActive, value.Image, value.Description);
            await _service.UpdateAsync(updateProductCategoryParameter);
            return Ok();
        }

        [HttpPatch("orders")]
        public async Task<IActionResult> UpdateOrders([FromBody] UpdateCategoryOrderParameterCollection parameterCollection)
        {
            try
            {

                await _service.UpdateOrder(parameterCollection);


                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<ProductCategorysController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
