using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Tariff
{
    public int Id { get; set; }

    public int LimitId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int InitialPaymentAmount { get; set; }

    public int PeriodSeconds { get; set; }

    public string ServiceType { get; set; } = null!;

    public int PeriodPaymentAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual Limit Limit { get; set; } = null!;

    public virtual ICollection<PackageTarif> PackageTarifs { get; } = new List<PackageTarif>();

    public virtual ICollection<Purchase> Purchases { get; } = new List<Purchase>();

    public virtual ICollection<TariffTvChannel> TariffTvChannels { get; } = new List<TariffTvChannel>();
}
