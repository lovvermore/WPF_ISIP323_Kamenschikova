using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class HallRating
{
    public int HallRatingId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HallId> HallIds { get; set; } = new List<HallId>();
}
