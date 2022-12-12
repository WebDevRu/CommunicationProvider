using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class TariffTvChannel
{
    public int Id { get; set; }

    public int TvChannelId { get; set; }

    public int TariffId { get; set; }

    public virtual Tariff Tariff { get; set; } = null!;

    public virtual Tvchannel TvChannel { get; set; } = null!;
}
