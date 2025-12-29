using System.ComponentModel.DataAnnotations;

namespace ServiceMS.Models;

public class ServiceRequest
{
    public long Id { get; set; }

    [Required, MaxLength(12)]
    public string TrackingCode { get; set; } = null!;

    [Required, MaxLength(120)]
    public string CustomerName { get; set; } = null!;

    [Required, MaxLength(30)]
    public string CustomerPhone { get; set; } = null!;

    [Required, MaxLength(120)]
    public string DeviceName { get; set; } = null!;

    [Required]
    public string IssueDescription { get; set; } = null!;

    public ServiceStatus Status { get; set; } = ServiceStatus.Open;

    // Identity’yi sonra ekleyeceğiz (şimdilik string)
    public string? AssignedTechnicianId { get; set; }
    public string CreatedByUserId { get; set; } = "system";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}