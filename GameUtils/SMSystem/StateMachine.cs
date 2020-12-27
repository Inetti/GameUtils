using GameUtils.LogSystem;
using GameUtils.SMSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GameUtils.SMSystem {
    public class StateMachine<T> : IStateMachine<T> where T : IState {
        private readonly Dictionary<string, T> states;
        private T currentState;

        public string CurrentState { get { return currentState.Name; } }

        public StateMachine() {
            states = new Dictionary<string, T>();
        }

        public void Init(T initState) {
            Add(initState);
            currentState = initState;
        }

        public void Add(T state) {
            if (states.ContainsKey(state.Name)) {
                return;
            }
            states.Add(state.Name, state);
        }

        public void Update() {
            currentState.Update();
        }

        public void SetState(string nextStateName) {
            if (currentState.IsNextStateValid(nextStateName)) {
                currentState = states[nextStateName];
            }
        }
    }
}
