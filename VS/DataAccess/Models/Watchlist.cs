using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Watchlist
{
    public int WatchlistId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();
}
