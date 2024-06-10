using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RuedarentApi.Vehicle.Domain.Model.Aggregates;
using RuedarentApi.Vehicle.Domain.Model.Commands;
using RuedarentApi.Vehicle.Domain.Model.Queries;
using RuedarentApi.Vehicle.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Services;
using RuedarentApi.Vehicle.Infraestructure.Repositories;
using RuedarentApi.Vehicle.Interface.REST.Resource;
using RuedarentApi.Vehicle.Interface.REST.Transform;

namespace RuedarentApi.Vehicle.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class VehicleController(IVehicleSourceRepository vehicleSourceRepository,IVehicleSourceCommandService vehicleSourceCommandService, IVehicleSourceQueryService vehicleSourceQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateVehicleSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateVehicleSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await vehicleSourceCommandService.Handle(createFavoriteSourceCommand);
        return CreatedAtAction(nameof(GetFavoriteSourceById), new { id = result.Id },
            VehicleSourceResourceFromEntityAssembler.toResourceFromEntity(result));
    }

    private async Task<ActionResult> GetFavoriteSourcesByVehicleApiKey(string vehicleApiKey)
    {
        var getFavoriteSourcesByVehicleApiKeyQuery = new GetVehicleSourceByVehicleApiKeyQuery(vehicleApiKey);
        var result = await vehicleSourceQueryService.Handle(getFavoriteSourcesByVehicleApiKeyQuery);
        var resources = result.Select(VehicleSourceResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetFavoriteSourceByVehiclesApiKeyAndSourceId(string vehiclesApiKey,
        string sourceId)
    {
        var getFavoriteSourceByVehiclesApiKeyAndSourceIdQuery =
            new GetVehicleSourceByVehicleApiKeyANDSourceIdQuery(vehiclesApiKey, sourceId);
        var result = await vehicleSourceQueryService.Handle(getFavoriteSourceByVehiclesApiKeyAndSourceIdQuery);
        if (result is null) return NotFound();
        var resource = VehicleSourceResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetVehicleSourceByIdQuery(id);
        var result = await vehicleSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = VehicleSourceResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet]
    public async Task<ActionResult> GetFavoriteSourceFromQuery([FromQuery] string vehiclesApiKey,
        [FromQuery] string sourceId = "")
    {
        return string.IsNullOrEmpty(sourceId)
            ? await GetFavoriteSourcesByVehicleApiKey(vehiclesApiKey)
            : await GetFavoriteSourceByVehiclesApiKeyAndSourceId(vehiclesApiKey, sourceId);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFavoriteSource(int id)
    {
        var favoritesource = await vehicleSourceRepository.FindByIdAsync(id);
        if (favoritesource == null) 
        {
            return NotFound();
        }

        await vehicleSourceRepository.DeleteFavoriteSourceAsync(favoritesource);

        return NoContent();

    }

    [HttpGet("user/{vehicleUserId}")]
    public async Task<ActionResult<IEnumerable<VehicleSource>>> GetFavoriteSourceByVehicleUserId(int vehicleUserId)
    {
        var favoritesource = await vehicleSourceRepository.FindByVehicleUserIdAsync(vehicleUserId);
        return Ok(favoritesource);
    }
}