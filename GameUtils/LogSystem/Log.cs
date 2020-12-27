using System;

namespace GameUtils.LogSystem {
    public class Log : ILog {
        public string Message { get; private set; } 
        public int ID { get; private set; }

        public Log(int id, string message) {
            ID = id;
            Message = message;
        }
    }
}