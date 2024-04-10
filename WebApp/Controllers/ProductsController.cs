using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IApplicationUnit application) : ControllerBase
    {
        private readonly IProductService _service = application.Products;

        // GET: api/<ProductsController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListProductParameter pagingParameter)
        {
            ProductSpecifications Productspecifications = new();
            Productspecifications
                .AddFilters(pagingParameter)
                .IncludeCategory();
            PagedList<ProductModel> res = await _service.GetPaged(Productspecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductParameter value)
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

        //PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateProductParameter value)
        {
            UpdateProductParameter updateTableParameter = new UpdateProductParameter(id, value.Order, value.CategoryId, value.Title, value.Image, value.Price, value.Description, value.IsNew, value.IsActive, value.Materials, value.Additives);
            await _service.UpdateAsync(updateTableParameter);
            return Ok();
        }
        [HttpPatch("{id}", Name = "[action]")]
        public async Task<IActionResult> UpdateProductPrice(int id, UpdateProductPriceParameter parameter)
        {

            try
            {
                await _service.UpdatePrice(new UpdateProductPriceParameter(id,parameter.Price));
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        [HttpGet("{id}/prices", Name = "GetProductPriceLogs")]
        public async Task<IActionResult> UpdateProductPrice(int id, [FromQuery] DatePeriodParameter parameter)
        {
            try
            {

                return Ok(await _service.ProductPriceLogs(id, parameter));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
