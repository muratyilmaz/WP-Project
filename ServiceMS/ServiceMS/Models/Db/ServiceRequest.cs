using System;
using System.Collections.Generic;

namespace ServiceMS.Models.Db;

public partial class ServiceRequest
{
    public long Id { get; set; }

    public string TrackingCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string DeviceName { get; set; } = null!;

    public string IssueDescription { get; set; } = null!;

    public short Status { get; set; }

    public string? AssignedTechnicianId { get; set; }

    public string CreatedByUserId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
