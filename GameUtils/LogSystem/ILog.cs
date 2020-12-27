using System;

namespace GameUtils.LogSystem {
    public interface ILog {
        int ID { get; }
        string Message { get; }
    }
}