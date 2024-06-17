using System;
using System.Collections.Generic;

namespace ChessApp.Models;

public partial class Tournament
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public DateOnly? EventDate { get; set; }

    public int? TourLvlId { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<PlayerTour> PlayerTours { get; set; } = new List<PlayerTour>();

    public virtual TourLvl? TourLvl { get; set; }
}
