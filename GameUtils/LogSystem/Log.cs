using System;

namespace GameUtils.LogSystem {
    public class Log : ILog {
        public string Message { get; private set; }
        
        public Log(string message) {
            Message = message;
        }
    }
}