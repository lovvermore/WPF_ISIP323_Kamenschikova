using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class AgeCategory
{
    public int AgeCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
