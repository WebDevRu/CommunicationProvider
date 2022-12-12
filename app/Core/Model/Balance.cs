using System;
using System.Collections.Generic;

namespace app.Core.Model;

public partial class Balance
{
    public int Id { get; set; }

    public int AbonentId { get; set; }

    public bool IsSystem { get; set; }

    public int Value { get; set; }

    public virtual Abonent Abonent { get; set; } = null!;

    public virtual ICollection<MoneyTransaction> MoneyTransactions { get; } = new List<MoneyTransaction>();
}
