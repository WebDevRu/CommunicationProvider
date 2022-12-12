using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Abonent
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsPasswordTemporary { get; set; }

    public string Status { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Address { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime LastLoginAt { get; set; }

    public virtual ICollection<Balance> Balances { get; } = new List<Balance>();

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();
}
