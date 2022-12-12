using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Tvchannel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<TariffTvChannel> TariffTvChannels { get; } = new List<TariffTvChannel>();
}
