using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUtils.Commander {
    public interface ICommander {
        int Count { get; }
        void Add(ICommand command);
        void Update();
    }
}
