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

    public long? assigned_technician_id { get; set; }

    public long created_by_user_id { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual user? assigned_technician { get; set; }

    public virtual user created_by_user { get; set; } = null!;
}
