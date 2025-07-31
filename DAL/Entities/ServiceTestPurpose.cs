using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class ServiceTestPurpose
{
    public long Id { get; set; }

    public bool? IsActive { get; set; }

    public long ServiceId { get; set; }

    public long TestPurposeId { get; set; }

    public virtual Service Service { get; set; } = null!;

    public virtual TestPurpose TestPurpose { get; set; } = null!;
}
