using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameUtils.SMSystem {
    public interface IStatable {
        string State { get; }
        string NextState { get; }
        void SetState(string nextState);
    }
}
