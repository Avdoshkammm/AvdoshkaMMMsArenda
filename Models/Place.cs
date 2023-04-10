using System;
using System.Collections.Generic;

namespace Arenda_2._0.Models;

public partial class Place
{
    public int Id { get; set; }

    public int Row { get; set; }

    public int PlaceNum { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual User User { get; set; } = null!;
}
