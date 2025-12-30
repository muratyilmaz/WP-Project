using System;
using System.Collections.Generic;

namespace ServiceMS.Models.Db;

public partial class user
{
    public long id { get; set; }

    public string username { get; set; } = null!;

    public string password_hash { get; set; } = null!;

    public string role { get; set; } = null!;

    public DateTime created_at { get; set; }

    public virtual ICollection<service_request> service_requestassigned_technicians { get; set; } = new List<service_request>();

    public virtual ICollection<service_request> service_requestcreated_by_users { get; set; } = new List<service_request>();
}
