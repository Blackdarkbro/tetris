using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "TetrinosConfig", menuName = "TetrisConfigs/Tetrinos Config", order = 0)]
    public class TetrinoConfig : ScriptableObject
    {
        public string[] tetrinosNames;
        public GameObject[] tetrinos;
    }
}