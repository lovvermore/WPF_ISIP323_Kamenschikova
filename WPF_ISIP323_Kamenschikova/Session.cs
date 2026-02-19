using System;
using System.Collections.Generic;

namespace WPF_ISIP323_Kamenschikova;

public partial class Session
{
    public int SessionId { get; set; }

    public int FilmId { get; set; }

    public int HallId { get; set; }

    public DateTime Date { get; set; }

    public decimal Price { get; set; }

    public virtual Film Film { get; set; } = null!;

    public virtual HallId Hall { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
