using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public int Duration { get; set; }

    public string Synopsis { get; set; } = null!;

    public string PosterUrl { get; set; } = null!;

    public int DirectorId { get; set; }

    public decimal? AverageRating { get; set; }

    public virtual Director Director { get; set; } = null!;

    public virtual ICollection<DiscussionThread> DiscussionThreads { get; set; } = new List<DiscussionThread>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();
}
