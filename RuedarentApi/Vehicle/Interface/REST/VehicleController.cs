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
public class VehicleController(IFavoriteSourceRepository favoriteSourceRepository,IFavoriteSourceCommandService favoriteSourceCommandService, IFavoriteSourceQueryService favoriteSourceQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await favoriteSourceCommandService.Handle(createFavoriteSourceCommand);
        return CreatedAtAction(nameof(GetFavoriteSourceById), new { id = result.Id },
            FavoriteSourceResourceFromEntityAssembler.toResourceFromEntity(result));
    }

    private async Task<ActionResult> GetFavoriteSourcesByVehicleApiKey(string vehicleApiKey)
    {
        var getFavoriteSourcesByVehicleApiKeyQuery = new GetFavoriteSourceByVehicleApiKeyQuery(vehicleApiKey);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourcesByVehicleApiKeyQuery);
        var resources = result.Select(FavoriteSourceResourceFromEntityAssembler.toResourceFromEntity);
        return Ok(resources);
    }

    private async Task<ActionResult> GetFavoriteSourceByVehiclesApiKeyAndSourceId(string vehiclesApiKey,
        string sourceId)
    {
        var getFavoriteSourceByVehiclesApiKeyAndSourceIdQuery =
            new GetFavoriteSourceByVehicleApiKeyANDSourceIdQuery(vehiclesApiKey, sourceId);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByVehiclesApiKeyAndSourceIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetFavoriteSourceById(int id)
    {
        var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
        var result = await favoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = FavoriteSourceResourceFromEntityAssembler.toResourceFromEntity(result);
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
        var favoritesource = await favoriteSourceRepository.FindByIdAsync(id);
        if (favoritesource == null) 
        {
            return NotFound();
        }

        await favoriteSourceRepository.DeleteFavoriteSourceAsync(favoritesource);

        return NoContent();

    }

    [HttpGet("user/{vehicleUserId}")]
    public async Task<ActionResult<IEnumerable<FavoriteSource>>> GetFavoriteSourceByVehicleUserId(int vehicleUserId)
    {
        var favoritesource = await favoriteSourceRepository.FindByVehicleUserIdAsync(vehicleUserId);
        return Ok(favoritesource);
    }
}