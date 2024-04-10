using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController(IApplicationUnit application) : ControllerBase
    {
        private readonly IMaterialService _service = application.Materials;

        // GET: api/<MaterialsController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListMaterialParameter pagingParameter)
        {
            MaterialSpecifications Materialspecifications = new MaterialSpecifications();
            Materialspecifications
                .AddFilters(pagingParameter)
                .AddIncludes();
            PagedList<MaterialModel> res = await _service.GetPaged(Materialspecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<MaterialsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<MaterialsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMaterialParameter value)
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

        // PUT api/<MaterialsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateMaterialParameter value)
        {
            UpdateMaterialParameter updateTableParameter = new UpdateMaterialParameter() { UnitPrice=value.UnitPrice, Id = id, UnitId = value.UnitId, Title = value.Title, IsActive = value.IsActive };
            await _service.UpdateAsync(updateTableParameter);
            return Ok();
        }

        // DELETE api/<MaterialsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
