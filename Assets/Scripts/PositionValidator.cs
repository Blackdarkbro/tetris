using DefaultNamespace.PlaygroundGrid;
using PlaygroundGrid;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class PositionValidator
    {
        private readonly Grid _grid;

        public PositionValidator(Grid grid)
        {
            _grid = grid;
        }

        public bool IsValidHorizontalPosition(Transform transform)
        {
            foreach (Transform subBlock in transform)
            {
                var subPosition = subBlock.position;
                if (subPosition.x >= _grid.Width || subPosition.x <= _grid.StartPoint.x)
                {
                    return false;
                }

                var gridTransform = GetTransformAtGridPosition(subPosition);
                if (gridTransform != null && gridTransform.parent != transform)
                {
                    return false;
                }
                
            }
            _grid.UpdateGrid(transform);
            return true;
        }

        public bool IsValidVerticalPosition(Transform transform)
        {
            foreach (Transform subBlock in transform)
            {
                var subPosition = subBlock.position;
                if (subPosition.y <= _grid.StartPoint.y)
                {
                    return false;
                }
                
                var gridTransform = GetTransformAtGridPosition(subPosition);
                if (gridTransform != null && gridTransform.parent != transform)
                {
                    return false;
                }
            }
            
            _grid.UpdateGrid(transform);
            return true;
        }

        public bool IsBadLeftPosition(Transform transform)
        {
            foreach (Transform subBlock in transform)
            {
                var subPosition = subBlock.position;
                if (subPosition.x <= _grid.StartPoint.x)
                {
                    return true;
                }
                
                var gridTransform = GetTransformAtGridPosition(subPosition);
                if (gridTransform != null && gridTransform.parent != transform)
                {
                    return false;
                }
            }
            return false;
        }

        public bool IsBadRightPosition(Transform transform)
        {
            foreach (Transform subBlock in transform)
            {
                var subPosition = subBlock.position;
                if (subPosition.x >= _grid.Width)
                {
                    return true;
                }
                
                var gridTransform = GetTransformAtGridPosition(subPosition);
                if (gridTransform != null && gridTransform.parent != transform)
                {
                    return false;
                }
            }
            return false;
        }

        private Transform GetTransformAtGridPosition(Vector3 position)
        {
            if (position.y > _grid.Height - 1) return null;
            
            return _grid.grid[(int) position.x, (int) position.y];
        }
    }
}