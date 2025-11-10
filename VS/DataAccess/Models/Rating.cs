using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Rating
{
    public int RatingId { get; set; }

    public int UserId { get; set; }

    public int MovieId { get; set; }

    public byte RatingValue { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
