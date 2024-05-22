using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Otklik
{
    public int IdOtklik { get; set; }

    public int IdVakansii { get; set; }

    public int IdKandidata { get; set; }

    public virtual Kandidati IdKandidataNavigation { get; set; }

    public virtual Vakansii IdVakansiiNavigation { get; set; }
}
