using System;
using Accessory.Builder.Core.Domain;

namespace Template.Core.Domain.User;

public class UserId : TypedIdValueBase
{
    public UserId(Guid value) : base(value) { }
        
    public static UserId Default => new UserId(default);
    public static UserId Generate() => new UserId(Guid.NewGuid());
}