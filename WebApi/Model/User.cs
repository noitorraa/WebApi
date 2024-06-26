﻿using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; }

    public string Parol { get; set; }

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();
}
