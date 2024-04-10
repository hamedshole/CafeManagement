using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController(IApplicationUnit application) : ControllerBase
    {
        private readonly ITableService _service = application.Tables;

        // GET: api/<TablesController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListTableParameter pagingParameter)
        {
            TableSpecifications tableSpecifications = new();
            tableSpecifications.AddFilters(pagingParameter);
            PagedList<TableModel> res = await _service.GetPaged(tableSpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<TablesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<TablesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTableParameter value)
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

        // PUT api/<TablesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateTableParameter value)
        {
            UpdateTableParameter updateTableParameter = new(id, value.Title, value.IsActive);
               await _service.UpdateAsync(updateTableParameter);
            return Ok();
        }

        // DELETE api/<TablesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
