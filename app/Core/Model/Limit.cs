using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Limit
{
    public int Id { get; set; }

    public bool IsSystem { get; set; }

    public string ServiceType { get; set; } = null!;

    public int CableInternetSpeedMbs { get; set; }

    public int MobileInternetLimitMb { get; set; }

    public int MobileCallsMinutes { get; set; }

    public virtual ICollection<Tariff> Tariffs { get; } = new List<Tariff>();
}
