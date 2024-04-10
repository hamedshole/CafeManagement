using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController(IApplicationUnit application) : ControllerBase
    {
        private readonly IInventoryService _service = application.Inventories;

        // GET: api/<InventorysController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListInventoryParameter pagingParameter)
        {
            InventorySpecifications InventorySpecifications = new InventorySpecifications();
            InventorySpecifications.AddFilters(pagingParameter);
            PagedList<InventoryModel> res = await _service.GetPaged(InventorySpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<InventorysController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<InventorysController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateInventoryParameter value)
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

        // PUT api/<InventorysController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateInventoryParameter value)
        {
            UpdateInventoryParameter updateInventoryParameter = new UpdateInventoryParameter() {   Id = id, Title = value.Title, IsActive = value.IsActive };
            await _service.UpdateAsync(updateInventoryParameter);
            return Ok();
        }

        // DELETE api/<InventorysController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
