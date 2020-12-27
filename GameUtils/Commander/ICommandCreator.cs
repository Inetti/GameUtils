using GameUtils.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUtils.Commander {
    public interface ICommandCreator {
        string CommandName { get; }
        bool Create(ICommander commander, string[] args);
    }
}
