using System;
using System.Collections.Generic;

namespace ChessApp.Models;

public partial class PlayerTour
{
    public int Id { get; set; }

    public int? PlayerId { get; set; }

    public int? TourId { get; set; }

    public int? StartNumber { get; set; }

    public int? ResultNumber { get; set; }

    public virtual Player? Player { get; set; }

    public virtual Tournament? Tour { get; set; }
}
