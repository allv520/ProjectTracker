using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Director
{
    public int DirectorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
