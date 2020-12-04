using System;
using DefaultNamespace;
using UnityEngine;
using Zenject;
using Grid = DefaultNamespace.Grid;

namespace PlaygroundGrid
{
    public class GridController : MonoBehaviour
    {
        [Inject] private Grid _grid;
        [Inject] private StatsController _statsController;

        public Vector3 GetSpawnPoint()
        {
            return new Vector3(_grid.StartPoint.x + _grid.Width / 2, 
                _grid.StartPoint.y + _grid.Height, 0); 
        }
        
        public void ClearRow()
        {
            for (int y = 0; y < _grid.Height; y++)
            {
                if (!IsFoolRowAt(y)) continue;
                
                _statsController.IncreaseLinesAndScore();
                DeleteSubBlock(y);
                MoveAllRowsDown(y + 1);
        
                --y;
            }
        }

        public bool CheckIsAboveGrid(TetrinoController tetrino)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                foreach (Transform subBlock in tetrino.transform)
                {
                    if (subBlock.position.y >= _grid.Height - 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsFoolRowAt(int y)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                if (_grid.grid[x, y] == null)
                {
                    return false;
                }
            }
        
            return true;
        }
        
        private void DeleteSubBlock(int y)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                Destroy(_grid.grid[x, y].gameObject);
                _grid.grid[x, y] = null;
            }
        }
        
        private void MoveAllRowsDown(int y)
        {
            for (int i = y; i < _grid.Height; i++)
            {
                MoveRowDown(i);
            }
        }
        
        private void MoveRowDown(int y)
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                if (_grid.grid[x, y] == null) continue;
                
                _grid.grid[x, y - 1] = _grid.grid[x, y];
                _grid.grid[x, y] = null;
                _grid.grid[x, y-1].position += Vector3.down;
            }
        }
    }
}