using System;
using System.Collections.Generic;

namespace marquee_backend.Models.Auth;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
