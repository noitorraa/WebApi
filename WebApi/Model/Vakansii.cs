using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Vakansii
{
    public int IdVakansii { get; set; }

    public int IdKompanii { get; set; }

    public string Trebovania { get; set; }

    public decimal Zarplata { get; set; }

    public DateOnly? DataPublikacii { get; set; }

    public decimal Telephon { get; set; }

    public virtual Companii IdKompaniiNavigation { get; set; }

    public virtual ICollection<Otklik> Otkliks { get; set; } = new List<Otklik>();

    public virtual ICollection<Sobesedovanie> Sobesedovanies { get; set; } = new List<Sobesedovanie>();
}
