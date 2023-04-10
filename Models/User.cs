using System;
using System.Collections.Generic;

namespace Arenda_2._0.Models;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public virtual ICollection<Place> Places { get; } = new List<Place>();

    public virtual Role RoleNavigation { get; set; } = null!;
}
