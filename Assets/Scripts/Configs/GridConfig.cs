using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "TetrisConfigs/GridConfig", order = 0)]
    public class GridConfig : ScriptableObject
    {
        public int width;
        public int height;

        public Vector3 bottomLeftBorderPoint;
    }
}