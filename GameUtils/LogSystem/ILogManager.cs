using System;

namespace GameUtils.LogSystem {
    public interface ILogManager {
        ILogger Logs { get; }
    }
}