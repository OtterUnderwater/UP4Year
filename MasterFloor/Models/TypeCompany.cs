using System;
using System.Collections.Generic;

namespace MasterFloor.Models;

public partial class TypeCompany
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
