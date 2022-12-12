using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class MoneyTransaction
{
    public int Id { get; set; }

    public int Credits { get; set; }

    public int BalanceId { get; set; }

    public int StartCredits { get; set; }

    public int EndCredits { get; set; }

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int PurchaseId { get; set; }

    public virtual Balance Balance { get; set; } = null!;

    public virtual Purchase Purchase { get; set; } = null!;
}
