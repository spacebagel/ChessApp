using System;
using System.Collections.Generic;

namespace ChessApp.Models;

public partial class SportRank
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
