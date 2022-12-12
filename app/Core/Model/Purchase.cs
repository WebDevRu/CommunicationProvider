using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Purchase
{
    public int Id { get; set; }

    public int AbonentId { get; set; }

    public int TariffId { get; set; }

    public int PackageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Abonent Abonent { get; set; } = null!;

    public virtual ICollection<MoneyTransaction> MoneyTransactions { get; } = new List<MoneyTransaction>();

    public virtual Package Package { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;
}
