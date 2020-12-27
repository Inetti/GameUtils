namespace GameUtils.SMSystem {
    public interface IStateMachine<T> where T : IState {
        string CurrentState { get; }
        void Init(T initState);
        void Add(T state);
        void Update();
        void SetState(string nextStateName);
    }
}
