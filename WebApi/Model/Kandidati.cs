using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Kandidati
{
    public int IdKandidata { get; set; }

    public int IdNavikakondidata { get; set; }

    public string Imea { get; set; }

    public string Familia { get; set; }

    public DateOnly DataRozhdenia { get; set; }

    public int? OpitRaboti { get; set; }

    public string Obrazovanie { get; set; }

    public decimal Telefon { get; set; }

    public virtual NavikiKandidatum IdNavikakondidataNavigation { get; set; }

    public virtual ICollection<NavikiKandidatum> NavikiKandidata { get; set; } = new List<NavikiKandidatum>();

    public virtual ICollection<Otklik> Otkliks { get; set; } = new List<Otklik>();

    public virtual ICollection<Sobesedovanie> Sobesedovanies { get; set; } = new List<Sobesedovanie>();
}
