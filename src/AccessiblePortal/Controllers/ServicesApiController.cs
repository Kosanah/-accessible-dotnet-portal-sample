using AccessiblePortal.Models;
using AccessiblePortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessiblePortal.Controllers;

/// <summary>REST API used by the front-end tracker and by other systems.
/// Returns problem details on errors, never stack traces or internal data.</summary>
[ApiController]
[Route("api/services")]
public class ServicesApiController(IServiceRequestService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ServiceRequest>>> List([FromQuery] string? filter)
        => await service.ListAsync(filter);

    [HttpGet("{reference}")]
    public async Task<ActionResult<ServiceRequest>> Get(string reference)
    {
        var item = await service.GetByReferenceAsync(reference);
        return item is null ? NotFound(new { error = "No request found for that reference." }) : item;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> Create(ServiceRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await service.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { reference = created.ReferenceNumber }, created);
    }
}
