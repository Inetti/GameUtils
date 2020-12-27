using GameUtils.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUtils.Commander {
    public class Commander : ICommander {
        private readonly Queue<ICommand> commands;
        private readonly Stack<ICommand> oldCommands;
        private ICommand currentCommand;

        public int Count { get { return commands.Count; } }

        public Commander() {
            commands = new Queue<ICommand>();
            oldCommands = new Stack<ICommand>();
        }

        public void Add(ICommand command) {
            commands.Enqueue(command);
        }

        public void Update() {
            if (commands.Count > 0) {
                ICommand currentCommand = commands.Peek();
                currentCommand.Update();
                if (currentCommand.IsDone || currentCommand.IsError) {
                    commands.Dequeue();
                    oldCommands.Push(currentCommand);
                }
            }
        }
    } 
}
