using System;
using Zenject;

namespace DefaultNamespace
{
    public class SpeedController : IInitializable, IDisposable
    {
        private float _fallSpeed;

        public float fallSpeed => _fallSpeed;

        private float buffer;

        private SignalBus _signalBus;

        public SpeedController(SignalBus signalBus)
        {
            _fallSpeed = 1;
            _signalBus = signalBus;
        }

        public void StopMoving()
        {
            buffer = _fallSpeed;
            _fallSpeed = 100;
            _signalBus.Fire<ChangedSpeedSignal>(new ChangedSpeedSignal(_fallSpeed));
        }
        
        public void ContinueMoving()
        {
            _fallSpeed = buffer;
            _signalBus.Fire<ChangedSpeedSignal>(new ChangedSpeedSignal(_fallSpeed));
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ChangedLevelSignal>(IncreaseSpeed);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<ChangedSpeedSignal>(IncreaseSpeed);
        }
        
        private void IncreaseSpeed()
        {
            _fallSpeed -= 0.1f;
            _signalBus.Fire<ChangedSpeedSignal>(new ChangedSpeedSignal(_fallSpeed));
        }
    }
}