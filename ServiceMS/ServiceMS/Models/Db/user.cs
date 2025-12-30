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
}
