using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TestCategory
{
    public long TestCategoryId { get; set; }

    public bool? IsActive { get; set; }

    public string Name { get; set; } = null!;

    public long? ServiceId { get; set; }

    public virtual Service? Service { get; set; }
}
