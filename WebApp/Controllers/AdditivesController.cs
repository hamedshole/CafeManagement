using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditivesController(IApplicationUnit application) : ControllerBase
    {
        private readonly IAdditiveService _service = application.Additives;

        // GET: api/<AdditivesController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListAdditiveParameter pagingParameter)
        {
            AdditiveSpecifications AdditiveSpecifications = new();
            AdditiveSpecifications.AddFilter(pagingParameter);
            PagedList<AdditiveModel> res = await _service.GetPaged(AdditiveSpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<AdditivesController>/5
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

        // POST api/<AdditivesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAdditiveParameter value)
        {
            try
            {
            await _service.CreateAsync(value);
            return Ok();

            }
            catch (Exception )
            {

                throw;
            }
        }

        // PUT api/<AdditivesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateAdditiveParameter value)
        {
            try
            {
                UpdateAdditiveParameter updateAdditiveParameter = new() { Price=value.Price,MaterialId=value.MaterialId,Amount=value.Amount, Id = id, Title = value.Title, IsActive = value.IsActive };
                await _service.UpdateAsync(updateAdditiveParameter);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<AdditivesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
