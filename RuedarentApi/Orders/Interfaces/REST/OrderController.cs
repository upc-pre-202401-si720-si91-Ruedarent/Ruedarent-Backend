using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RuedarentApi.Orders.Domain.Model.Queries;
using RuedarentApi.Orders.Domain.Repositories;
using RuedarentApi.Orders.Domain.Services;
using RuedarentApi.Orders.Interfaces.REST.Resources;
using RuedarentApi.Orders.Interfaces.REST.Transform;
using RuedarentApi.Plans.Domain.Repositories;

namespace RuedarentApi.Orders.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class OrderController(IOrderRepository orderRepository,IOrderCommandService orderCommandService, IOrderQueryService orderQueryService, IPlanRepository planRepository) : ControllerBase
{
    [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderResource resource)
        {
            var createOrderCommand =
                CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
            var plan = await planRepository.FindByIdAsync(createOrderCommand.PlanId);
            if (plan == null)
            {
                return BadRequest("Plan not found");
            }
            var result = await orderCommandService.Handle(createOrderCommand,plan);
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id },
                OrderResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        
    [HttpGet("owner/{ownerName}")]
        public async Task<IActionResult> GetOrderByOwnerName(string ownerName)
        {
            var getOrderByOwnerNameQuery = new GetOrderByOwnerNameQuery(ownerName);
            var results = await orderQueryService.Handle(getOrderByOwnerNameQuery);
            var resources = results.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        
    
    [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var getOrderByIdQuery = new GetOrderByIdQuery(id);
            var result = await orderQueryService.Handle(getOrderByIdQuery);
            var resource = OrderResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        
    [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var getAllOrdersQuery = new GetAllOrdersQuery();
            var orders = await orderQueryService.Handle(getAllOrdersQuery);
            var resources = orders.Select(OrderResourceFromEntityAssembler
                .ToResourceFromEntity);
            return Ok(resources);
        }
        
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        var order = await orderRepository.FindByIdAsync(id);
        if (order == null) 
        {
            return NotFound();
        }

        await orderRepository.DeleteOrderAsync(order);

        return NoContent();

    }
}