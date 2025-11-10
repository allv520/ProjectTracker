using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int MovieId { get; set; }

    public string ReviewText { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
