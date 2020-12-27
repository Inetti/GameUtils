using System;

namespace GameUtils.LogSystem {
    public delegate void ViewMessage(string message);
    public interface ILogger {
        event ViewMessage OnViewMessage;
        void Add(string message); 
    }
}