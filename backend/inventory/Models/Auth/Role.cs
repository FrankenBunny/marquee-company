using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Auth;

public partial class Role
{
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
