using AccessiblePortal.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace AccessiblePortal.Tests;

public class ServiceRequestTests
{
    private static List<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(model, new ValidationContext(model), results, true);
        return results;
    }

    [Fact]
    public void MissingEmail_FailsValidation()
    {
        var request = new ServiceRequest
        {
            ServiceName = "Benefits", FullName = "Test User", Email = "",
            Description = "I need help with a benefits question."
        };
        Assert.NotEmpty(Validate(request));
    }

    [Fact]
    public void ShortDescription_FailsValidation()
    {
        var request = new ServiceRequest
        {
            ServiceName = "Records", FullName = "Test User", Email = "test@example.com",
            Description = "Too short"
        };
        Assert.NotEmpty(Validate(request));
    }

    [Fact]
    public void ValidRequest_PassesValidation()
    {
        var request = new ServiceRequest
        {
            ServiceName = "Licenses", FullName = "Test User", Email = "test@example.com",
            Description = "I need to renew a license and update my address."
        };
        Assert.Empty(Validate(request));
    }
}
