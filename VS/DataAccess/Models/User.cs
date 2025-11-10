using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Bio { get; set; } = null!;

    public string AvatarUrl { get; set; } = null!;

    public virtual ICollection<DiscussionThread> DiscussionThreads { get; set; } = new List<DiscussionThread>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
}
