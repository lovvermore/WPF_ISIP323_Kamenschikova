using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class Film
{
    public int FilmId { get; set; }

    public string Name { get; set; } = null!;

    public int Rating { get; set; }

    public int AgeCategoryId { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public virtual AgeCategory AgeCategory { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public static implicit operator Film(Session v)
    {
        throw new NotImplementedException();
    }
}
