using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Navik
{
    public int IdNavika { get; set; }

    public string NazvanieNavika { get; set; }

    public virtual ICollection<NavikiKandidatum> NavikiKandidata { get; set; } = new List<NavikiKandidatum>();
}
