using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace marquee_backend.Models.Auth;

public partial class User
{
    [SwaggerSchema(ReadOnly = true)]
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
