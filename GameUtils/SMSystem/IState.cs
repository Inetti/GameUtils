namespace GameUtils.SMSystem {
    public interface IState  {
        string Name { get; }
        string GetNextState();
        void Update();
        bool IsNextStateValid(string nextState);
    }
}