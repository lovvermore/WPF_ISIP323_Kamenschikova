using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class Seat
{
    public int SeatId { get; set; }

    public int SessionId { get; set; }

    public int RowNumber { get; set; }

    public int SeatNumber { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
