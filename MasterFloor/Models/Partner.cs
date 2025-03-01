using System;
using System.Collections.Generic;

namespace MasterFloor.Models;

public partial class Partner
{
    public int Id { get; set; }

    public int IdTypeCompany { get; set; }

    public string Title { get; set; } = null!;

    public string? LegalAddress { get; set; }

    public string? Inn { get; set; }

    public string? DirectorFio { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? Rating { get; set; }

    public virtual TypeCompany IdTypeCompanyNavigation { get; set; } = null!;

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
