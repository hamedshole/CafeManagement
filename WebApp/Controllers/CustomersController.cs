using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IApplicationUnit application) : ControllerBase
    {
        private readonly ICustomerService _service = application.Customers;

        // GET: api/<CustomersController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListCustomerParameter pagingParameter)
        {
            CustomerSpecifications CustomerSpecifications = new();
            CustomerSpecifications.AddFilters(pagingParameter);
            PagedList<CustomerModel> res = await _service.GetPaged(CustomerSpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerParameter value)
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

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CreateCustomerParameter value)
        {
            UpdateCustomerParameter updateCustomerParameter = new UpdateCustomerParameter() { Code = value.Code, Birthday = value.Birthday, PhoneNumber = value.PhoneNumber, Gender = value.Gender, Id = id, FirstName = value.FirstName, LastName = value.LastName };
            await _service.UpdateAsync(updateCustomerParameter);
            return Ok();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
