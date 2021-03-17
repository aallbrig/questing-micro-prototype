using UnityEngine;

namespace Interfaces
{
    public interface ISpawnable<T>
    {
        T Spawnable { get; }
    }
}