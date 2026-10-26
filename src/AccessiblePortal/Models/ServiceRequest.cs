using System.ComponentModel.DataAnnotations;

namespace AccessiblePortal.Models;

public enum RequestStatus { Submitted, InReview, InProgress, Completed }

public class ServiceRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Service is required.")]
    public string ServiceName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Your full name is required.")]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please describe your request.")]
    [StringLength(2000, MinimumLength = 10,
        ErrorMessage = "Description must be between 10 and 2000 characters.")]
    public string Description { get; set; } = string.Empty;

    // Never store free-text sensitive data in this sample; keep it to the request itself.
    public RequestStatus Status { get; set; } = RequestStatus.Submitted;
    public string ReferenceNumber { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
