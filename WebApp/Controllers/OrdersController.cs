using Application.Helpers.Specifications;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IApplicationUnit application) : ControllerBase
    {
        private readonly IOrderService _service = application.Orders;

        // GET: api/<OrdersController>
        [HttpGet]

        public async Task<IActionResult> GetPagedList([FromQuery] ListOrderParameter pagingParameter)
        {
            OrderSpecifications OrderSpecifications = new();
            OrderSpecifications.AddFilter(pagingParameter);
            PagedList<OrderModel> res = await _service.GetPaged(OrderSpecifications, pagingParameter);
            return Ok(res);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _service.GetById(id);
            return Ok(res);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderParameter value)
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

  
        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
