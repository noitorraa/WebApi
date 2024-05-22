using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Companii
{
    public int IdCompanii { get; set; }

    public string Naimenovanie { get; set; }

    public string FamiliaDirectora { get; set; }

    public string ImeaDirectora { get; set; }

    public string OtchestvoDirectora { get; set; }

    public virtual ICollection<Vakansii> Vakansiis { get; set; } = new List<Vakansii>();
}
