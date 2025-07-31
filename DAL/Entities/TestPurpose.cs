using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class TestPurpose
{
    public long TestPurposeId { get; set; }

    public bool? IsActive { get; set; }

    public string? TestPurposeDescription { get; set; }

    public string TestPurposeName { get; set; } = null!;

    public virtual ICollection<ServiceTestPurpose> ServiceTestPurposes { get; set; } = new List<ServiceTestPurpose>();
}
