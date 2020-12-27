using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUtils.Commander {
    public interface ICommand {
        bool IsDone { get; }
        bool IsError { get; }
        void Update();
    }
}
