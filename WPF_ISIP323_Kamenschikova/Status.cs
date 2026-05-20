using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
}
