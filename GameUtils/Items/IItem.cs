using System;

namespace GameUtils.Items {
    public interface IItem {
        string Name { get; }
        int Size { get; }
        IItem Copy();
    }
}