using Zenject;

namespace DefaultNamespace
{
    public class StatsController
    {
        private float _score;
        private float _lines;

        private SignalBus _signalBus;
        
        public StatsController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void DefaultIncreaseScore()
        {
            _score++;
            _signalBus.Fire<ChangedStatsSignal>(new ChangedStatsSignal(){score = _score});
        }

        public void IncreaseLinesAndScore()
        {
            _score += 100;
            _lines++;
            _signalBus.Fire<ChangedStatsSignal>(new ChangedStatsSignal(){score = _score, lines = _lines});
        }
        
        
    }
}