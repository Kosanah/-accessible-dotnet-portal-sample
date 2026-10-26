using AccessiblePortal.Models;
using AccessiblePortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessiblePortal.Controllers;

public class ServicesController(IServiceRequestService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(string? filter)
    {
        ViewData["Filter"] = filter;
        return View(await service.ListAsync(filter));
    }

    [HttpGet]
    public IActionResult New() => View(new ServiceRequest());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> New(ServiceRequest request)
    {
        if (!ModelState.IsValid)
        {
            // Return the same view so validation errors are announced
            // in place, next to each field — see the view's validation summary.
            return View(request);
        }
        var created = await service.CreateAsync(request);
        TempData["Success"] = $"Request submitted. Your reference is {created.ReferenceNumber}.";
        return RedirectToAction(nameof(Track), new { reference = created.ReferenceNumber });
    }

    [HttpGet]
    public async Task<IActionResult> Track(string? reference)
    {
        if (string.IsNullOrWhiteSpace(reference)) return View(null as ServiceRequest);
        return View(await service.GetByReferenceAsync(reference));
    }
}
