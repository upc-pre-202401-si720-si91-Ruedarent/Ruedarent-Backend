using System.Net.Mime;

using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Model.Queries;
using ACME.LearningCenter_Platform.VehiclesInformation.Domain.Services;
using ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.LearningCenter_Platform.VehiclesInformation.Interfaces.Rest;

[ApiController]
[Route("/api/v1/categories/{categoryId}/tutorials")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoryVehiclesController(IVehicleQueryServices vehicleQueryServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTutorialsByCategoryId([FromRoute] int categoryId)
    {
        var getAllTutorialsByCategoryIdQuery = new GetAllVehiclesByCategoryIdQuery(categoryId);
        var tutorials = await vehicleQueryServices.Handle(getAllTutorialsByCategoryIdQuery);
        var resource = tutorials.Select(VehicleResourceFromEntityAssembler
            .ToResourceFromEntity);
        return Ok(resource);
    }
}