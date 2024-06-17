using System;
using System.Collections.Generic;

namespace ChessApp.Models;

public partial class Player
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public int? SportRankId { get; set; }

    public bool? IsWorldChampionContender { get; set; }

    public int? Rating { get; set; }

    public int? CountryId { get; set; }

    public string? Note { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<PlayerTour> PlayerTours { get; set; } = new List<PlayerTour>();

    public virtual SportRank? SportRank { get; set; }
}
