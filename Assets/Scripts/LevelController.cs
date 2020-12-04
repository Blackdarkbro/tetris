using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class LevelController : IInitializable
    {
        private int _level;
        
        private SignalBus _signalBus;

        public LevelController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<ChangedStatsSignal>((x) =>
            {
                UpgradeLevel(x.score);
            });
        }

        private void UpgradeLevel(float score)
        {
            if (score % 100 < 0) return;
            _level++;
            _signalBus.Fire<ChangedLevelSignal>(new ChangedLevelSignal(_level));
        }
    }
}