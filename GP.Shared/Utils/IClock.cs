using System;

namespace GP.Shared.Utils
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}
