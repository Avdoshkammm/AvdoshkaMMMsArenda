using System;
using System.Collections.Generic;

namespace Arenda_2._0.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdPlace { get; set; }

    public virtual Place IdPlaceNavigation { get; set; } = null!;
}
