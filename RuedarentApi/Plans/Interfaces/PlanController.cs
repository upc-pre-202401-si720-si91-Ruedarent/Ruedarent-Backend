using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RuedarentApi.Orders.Domain.Model.Queries;
using RuedarentApi.Orders.Interfaces.REST.Resources;
using RuedarentApi.Orders.Interfaces.REST.Transform;
using RuedarentApi.Plans.Domain.Model.Queries;
using RuedarentApi.Plans.Domain.Repositories;
using RuedarentApi.Plans.Domain.Services;
using RuedarentApi.Plans.Interfaces.REST.Transform;

namespace RuedarentApi.Plans.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class PlanController(IPlanRepository planRepository, IPlanQueryService planQueryService) : ControllerBase
{
    
    [HttpGet("{id}")]
        public async Task<ActionResult> GetPlanById(int id)
        {
            var getPlanByIdQuery = new GetPlanByIdQuery(id);
            var result = await planQueryService.Handle(getPlanByIdQuery);
            var resource = PlanResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        
    [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var getAllPlansQuery = new GetAllPlansQuery();
            var plans = await planQueryService.Handle(getAllPlansQuery);
            var resources = plans.Select(PlanResourceFromEntityAssembler
                .ToResourceFromEntity);
            return Ok(resources);
        }
        
}