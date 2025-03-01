using System;
using System.Collections.Generic;

namespace MasterFloor.Models;

public partial class PartnerProduct
{
    public int IdProduct { get; set; }

    public int IdPartner { get; set; }

    public int CountProducts { get; set; }

    public DateTime SaleDate { get; set; }

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
