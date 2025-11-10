using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class DiscussionThread
{
    public int ThreadId { get; set; }

    public int UserId { get; set; }

    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
