using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int SessionId { get; set; }

    public int SeatId { get; set; }

    public int UserId { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual Session Session { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
