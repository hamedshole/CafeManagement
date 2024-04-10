using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController(IApplicationUnit application) : ControllerBase
    {
        private readonly IUnitService _service = application.Units;

        // GET: api/<UnitsController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListUnitParameter pagingParameter)
        {
            try
            {

                UnitSpecifications Unitspecifications = new();
                Unitspecifications.AddFilters(pagingParameter);
                Unitspecifications.AddIncludes();
                PagedList<UnitModel> res = await _service.GetPaged(Unitspecifications, pagingParameter);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<UnitsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var res = await _service.GetById(id);
                return Ok(res);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<UnitsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUnitParameter value)
        {
            if (value.ParentId == 0)
                value.ParentId = null;
            await _service.CreateAsync(value);
            return Ok();
        }

        // PUT api/<UnitsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateUnitParameter value)
        {
            try
            {
                if (value.ParentId == 0)
                    value.ParentId = null;
                UpdateUnitParameter updateTableParameter = new(id, value.Title, value.ParentId, value.Relation, value.IsActive);
                await _service.UpdateAsync(updateTableParameter);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<UnitsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
