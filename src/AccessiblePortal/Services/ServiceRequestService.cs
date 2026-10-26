using AccessiblePortal.Data;
using AccessiblePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessiblePortal.Services;

public interface IServiceRequestService
{
    Task<ServiceRequest> CreateAsync(ServiceRequest request, CancellationToken ct = default);
    Task<ServiceRequest?> GetByReferenceAsync(string reference, CancellationToken ct = default);
    Task<List<ServiceRequest>> ListAsync(string? serviceFilter, CancellationToken ct = default);
}

public class ServiceRequestService(AppDbContext db) : IServiceRequestService
{
    public async Task<ServiceRequest> CreateAsync(ServiceRequest request, CancellationToken ct = default)
    {
        // Reference format is deterministic and testable: SR-YYYYMMDD-XXXX
        request.ReferenceNumber = $"SR-{DateTime.UtcNow:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}";
        request.Status = RequestStatus.Submitted;
        request.CreatedAtUtc = DateTime.UtcNow;
        db.ServiceRequests.Add(request);
        await db.SaveChangesAsync(ct);
        return request;
    }

    public Task<ServiceRequest?> GetByReferenceAsync(string reference, CancellationToken ct = default)
        // Parameterized EF query only — no string-concatenated SQL anywhere.
        => db.ServiceRequests.FirstOrDefaultAsync(
            r => r.ReferenceNumber == reference.Trim().ToUpperInvariant(), ct);

    public Task<List<ServiceRequest>> ListAsync(string? serviceFilter, CancellationToken ct = default)
    {
        var query = db.ServiceRequests.AsNoTracking().OrderByDescending(r => r.CreatedAtUtc);
        if (!string.IsNullOrWhiteSpace(serviceFilter))
            query = (IOrderedQueryable<ServiceRequest>)query.Where(r => r.ServiceName == serviceFilter);
        return query.Take(100).ToListAsync(ct);
    }
}
