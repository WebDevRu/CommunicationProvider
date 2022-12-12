using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class PackageTarif
{
    public int Id { get; set; }

    public int TariffId { get; set; }

    public int PackageId { get; set; }

    public virtual Package Package { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;
}
