using System;
using Thucook.Commons.Enums;

namespace Thucook.Core
{
    public interface ICurrentContext
    {
        Guid? UserId { get; }
        UserTypeEnum? UserTypeId { get; }
        Guid LocationId { get; }

    }
}
