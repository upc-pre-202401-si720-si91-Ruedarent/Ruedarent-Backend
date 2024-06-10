using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using RuedarentApi.UserProfile.Domain.Model.Queries;
using RuedarentApi.UserProfile.Domain.Repositories;
using RuedarentApi.UserProfile.Domain.Services;
using RuedarentApi.UserProfile.Interface.REST.Resource;
using RuedarentApi.UserProfile.Interface.REST.Transform;

namespace RuedarentApi.UserProfile.Interface.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IUserSourceRepository userSourceRepository, IUserSourceCommandService userSourceCommandService, IUserSourceQueryService userSourceQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateUserSource([FromBody] CreateUserSourceResource resource)
    {
        var createFavoriteSourceCommand =
            CreateUserSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await userSourceCommandService.Handle(createFavoriteSourceCommand);
        return CreatedAtAction(nameof(GetUserSourceById), new { id = result.Id },
            UserSourceResourceFromEntityAssembler.toResourceFromEntity(result));
    }
    
    
    private async Task<ActionResult> GetUserbyDNI(int dni)
    {   
        var getUserSourceByDNIQuery = new GetUserSourceByDNIQuery(dni);
        var result = await userSourceQueryService.Handle(getUserSourceByDNIQuery);
        if (result is null) return NotFound();
        var resource = UserSourceResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserSourceById(int id)
    {
        var getUserSourceByIdQuery = new GetUserSourceByIdQuery(id);
        var result = await userSourceQueryService.Handle(getUserSourceByIdQuery);
        if (result is null) return NotFound();
        var resource = UserSourceResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetUserSourceByDNI([FromQuery] int dni)
    {
        var getUserSourceByDNIQuery = new GetUserSourceByDNIQuery(dni);
        var result = await userSourceQueryService.Handle(getUserSourceByDNIQuery);
        if (result is null) return NotFound();
        var resource = UserSourceResourceFromEntityAssembler.toResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserSource(int id)
    {
        var favoritesource = await userSourceRepository.FindByIdAsync(id);
        if(favoritesource is null) return NotFound();
        await userSourceRepository.DeleteUser(favoritesource);
        return NoContent();
    }
    
}