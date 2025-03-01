using System;
using System.Collections.Generic;

namespace MasterFloor.Models;

public partial class Product
{
    public int Id { get; set; }

    public int IdType { get; set; }

    public string Title { get; set; } = null!;

    public string Article { get; set; } = null!;

    public decimal MinCost { get; set; }

    public virtual ProductType IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
