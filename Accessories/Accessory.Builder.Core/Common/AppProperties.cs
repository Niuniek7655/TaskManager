using System;

namespace Accessory.Builder.Core.Common;

public class AppProperties
{
    public string? Name { get; set; }

    public Guid InstanceId { get; } = Guid.NewGuid();

    public string? Version { get; set; }
}