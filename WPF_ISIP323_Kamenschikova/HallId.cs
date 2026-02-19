using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class HallId
{
    public int HallId1 { get; set; }

    public int HallRatingId { get; set; }

    public int SeatsCountInRow { get; set; }

    public int RowwCount { get; set; }

    public virtual HallRating HallRating { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
