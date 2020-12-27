using System;
using System.Collections.Generic;

namespace GameUtils.LogSystem {
    public class Logger : ILogger {
        public event ViewMessage OnViewMessage;
        
        private readonly List<ILog> logList;
        
        public Logger() {
            logList = new List<ILog>();
        }
        
        public void Add(string logMessage) {
            ILog log = new Log(logList.Count, logMessage);
            logList.Add(log);
            if (OnViewMessage != null) {
                OnViewMessage(string.Format("{0}: {1}", log.ID, log.Message));
            }
        }
    }
}