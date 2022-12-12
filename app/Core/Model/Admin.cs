using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Admin
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public DateTime RegisteredAt { get; set; }

    public DateTime LastLoginAt { get; set; }

    public string Email { get; set; } = null!;
}
