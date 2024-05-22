using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Sobesedovanie
{
    public int IdSobesedovania { get; set; }

    public int IdKandidata { get; set; }

    public int IdVakansii { get; set; }

    public int IdSotrudnika { get; set; }

    public DateTime? DataIVremiaSobesedovania { get; set; }

    public string RezultatiSobesedovania { get; set; }

    public virtual Kandidati IdKandidataNavigation { get; set; }

    public virtual Sotrudniki IdSotrudnikaNavigation { get; set; }

    public virtual Vakansii IdVakansiiNavigation { get; set; }
}
