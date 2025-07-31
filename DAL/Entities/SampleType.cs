using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class SampleType
{
    public long Id { get; set; }

    public long KitComponentId { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CollectedSample> CollectedSamples { get; set; } = new List<CollectedSample>();

    public virtual KitComponent KitComponent { get; set; } = null!;
}
