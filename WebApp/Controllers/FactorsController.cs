using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactorsController(IApplicationUnit application) : ControllerBase
    {
        private readonly IFactorService _service = application.Factors;

        // GET: api/<FactorsController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListFactorParameter pagingParameter)
        {
            FactorSpecifications factorSpecifications = new FactorSpecifications();
            factorSpecifications.AddFilters(pagingParameter);
            PagedList<FactorModel> res = await _service.GetPaged(factorSpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<FactorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<FactorsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFactorParameter value)
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

      

        // DELETE api/<FactorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
