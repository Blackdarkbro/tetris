using DefaultNamespace.PlaygroundGrid;
using UnityEngine;

namespace DefaultNamespace
{
    public class Grid : IGrid
    {
        public int Width { get; }
        public int Height { get; }
        
        public Vector3 StartPoint { get; }

        public Transform[,] grid { get; }

        private GridConfig _gridConfig;

        public Grid(GridConfig gridConfig)
        {
            _gridConfig = gridConfig;

            StartPoint = _gridConfig.bottomLeftBorderPoint;
            
            Width = _gridConfig.width;
            Height = _gridConfig.height;
            
            grid = new Transform[Width,Height];
        }
        
        public void UpdateGrid(Transform transform)
        {
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    if (grid[x, y] != null)
                    {
                        if (grid[x, y].parent == transform)
                        {
                            grid[x, y] = null;
                        }
                    }
                }
            }
        
            foreach (Transform subBlock in transform)
            {
                var pos = subBlock.position;
                if (pos.y < Height)
                {
                    grid[(int) pos.x, (int) pos.y] = subBlock;
                }
            }
        }
    }
}