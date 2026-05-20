using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class SessionSeat
{
    public int SessionId { get; set; }

    public int SeatId { get; set; }

    public bool Status { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual Session Session { get; set; } = null!;
}
