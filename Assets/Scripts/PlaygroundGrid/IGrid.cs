using UnityEngine;

namespace DefaultNamespace.PlaygroundGrid
{
    public interface IGrid
    {
        int Width { get; }
        int Height { get; }
        Vector3 StartPoint { get; }
        Transform[,] grid { get; }
    }
}