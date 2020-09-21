using System;
using System.Collections.Generic;

namespace GameUtils.LogSystem {
    public class Logger : ILogger {
        public event ViewMessage OnViewMessage;
        
        private readonly List<ILog> logList;
        
        public Logger() {
            logList = new List<ILog>();
        }
        
        public void Add(ILog log) {
            logList.Add(log);
            if (OnViewMessage != null) {
                OnViewMessage(log.Message);
            }
        }
    }
}