using System;
using System.Collections.Generic;

namespace WebApi.Model;

public partial class Kontrakti
{
    public int IdKontrakta { get; set; }

    public int IdSotrudnika { get; set; }

    public DateOnly DataNachalaKontrakta { get; set; }

    public DateOnly? DataOkonchaniaKontrakta { get; set; }

    public decimal Zarplata { get; set; }

    public string GraphicRaboti { get; set; }

    public virtual Sotrudniki IdSotrudnikaNavigation { get; set; }
}
