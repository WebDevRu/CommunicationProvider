using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Package
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string ServiceType { get; set; } = null!;

    public int PeriodSeconds { get; set; }

    public int InitialPaymentAmount { get; set; }

    public int PeriodPaymentAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<PackageTarif> PackageTarifs { get; } = new List<PackageTarif>();

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();
}
