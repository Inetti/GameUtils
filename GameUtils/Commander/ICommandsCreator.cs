using GameUtils.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUtils.Commander  {
    public interface ICommandsCreator {
        void Add(ICommandCreator creator);
        bool CreateCommand(ICommander commander, string commandName, string[] args);
    }
}