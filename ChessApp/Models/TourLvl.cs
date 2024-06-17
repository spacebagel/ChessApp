using System;
using System.Collections.Generic;

namespace ChessApp.Models;

public partial class TourLvl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Tournament> Tournaments { get; set; } = new List<Tournament>();
}
