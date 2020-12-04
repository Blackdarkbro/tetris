using Zenject;

namespace DefaultNamespace
{
    public class TetrinoDroppedSignal
    {
        public TetrinoDroppedSignal(TetrinoController tetrinoController, GameController gameController)
        {
            TetrinoController = tetrinoController;
            GameController = gameController;
        }
        
        public TetrinoController TetrinoController { get; }
        public GameController GameController { get; }
    }
}