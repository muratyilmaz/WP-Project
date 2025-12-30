using System;
using System.Collections.Generic;

namespace ServiceMS.Models.Db;

public partial class service_request
{
    public long id { get; set; }

    public string tracking_code { get; set; } = null!;

    public string customer_name { get; set; } = null!;

    public string customer_phone { get; set; } = null!;

    public string device_name { get; set; } = null!;

    public string issue_description { get; set; } = null!;

    public short status { get; set; }

    public string? assigned_technician_id { get; set; }

    public string created_by_user_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }
}
