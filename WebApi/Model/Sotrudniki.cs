using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Sotrudniki
{
    public int IdSotrudnika { get; set; }

    public int IdDolzhnosti { get; set; }

    public int IdUser { get; set; }

    public string Imea { get; set; }

    public string Familia { get; set; }

    public string Otchestvo { get; set; }

    public string Adres { get; set; }

    public string Telephon { get; set; }

    public virtual Dolzhnosti IdDolzhnostiNavigation { get; set; }

    public virtual User IdUserNavigation { get; set; }

    public virtual ICollection<Kontrakti> Kontraktis { get; set; } = new List<Kontrakti>();

    public virtual ICollection<Sobesedovanie> Sobesedovanies { get; set; } = new List<Sobesedovanie>();
}
