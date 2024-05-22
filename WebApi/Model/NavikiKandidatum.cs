using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class NavikiKandidatum
{
    public int IdNavikaKondidata { get; set; }

    public int IdKandidata { get; set; }

    public int IdNavika { get; set; }

    public virtual Kandidati IdKandidataNavigation { get; set; }

    public virtual Navik IdNavikaNavigation { get; set; }

    public virtual ICollection<Kandidati> Kandidatis { get; set; } = new List<Kandidati>();
}
