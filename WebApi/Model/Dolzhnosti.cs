using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Dolzhnosti
{
    public int IdDolzhnosti { get; set; }

    public string NazvanieDolzhnosti { get; set; }

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();
}
