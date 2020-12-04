using System;
using System.Runtime.InteropServices;
using DefaultNamespace;
using UnityEngine;
using Zenject;

public class TetrinoController : MonoBehaviour
{
    [Inject] private readonly PositionValidator _positionValidator;
        
    [Inject] private readonly MovementCommands _movementCommands;
       
    [Inject] private readonly GameController _gameController;

    [Inject] private readonly StatsController _statsController;

    [Inject]
    public float _fallSpeed;

    [Inject]
    private SignalBus _signalBus;

    private float _fall = 0;

    private void Awake()
    {
        _signalBus.Subscribe<ChangedSpeedSignal>((x =>
        {
            _fallSpeed = x.fallSpeed;
        }));
    }

    private void Update()
    {
        MoveTetrino();
    }
        
    public void MoveTetrino()
    {
        MoveTetrinoLeft();
        MoveTetrinoRight();
        RotateTetrino();
        MoveTetrinoDown();
    }
        
    private void MoveTetrinoRight()
    {
        if (!Input.GetKeyDown(KeyCode.D)) return;
        
       // _audioManager.PlayMove();
        _movementCommands.MoveRight(gameObject);
            
        if (!_positionValidator.IsValidHorizontalPosition(transform))
        {
            _movementCommands.MoveLeft(gameObject);
        }
    }
        
    private void MoveTetrinoLeft()
    {
        if (!Input.GetKeyDown(KeyCode.A)) return;
            
        //_audioManager.PlayMove();
        _movementCommands.MoveLeft(gameObject);
            
        if (!_positionValidator.IsValidHorizontalPosition(transform))
        {
            _movementCommands.MoveRight(gameObject);
        }
    }
        
    private void MoveTetrinoDown()
    {
        if (Input.GetKey(KeyCode.S) || Time.time - _fall >= _fallSpeed)
        {
            _movementCommands.MoveDown(gameObject);
            _statsController.DefaultIncreaseScore();

            if (!_positionValidator.IsValidVerticalPosition(transform))
            {
                _movementCommands.StopMove(gameObject);
                _signalBus.Fire(new TetrinoDroppedSignal(this, _gameController));
            }
            _fall = Time.time;
        }
    }
        
    private void RotateTetrino()
    {
        if (!Input.GetKeyDown(KeyCode.W)) return;
            
       // _audioManager.PlayRotate();
        _movementCommands.Rotate(gameObject);
            
        if (_positionValidator.IsBadLeftPosition(transform))
        {
            _movementCommands.MoveRight(gameObject);
        } 
        if (_positionValidator.IsBadRightPosition(transform))
        {
            _movementCommands.MoveLeft(gameObject);
        }
    }
        
    public class Factory : PlaceholderFactory<float, GameController, TetrinoController>
    {
        
    }
}