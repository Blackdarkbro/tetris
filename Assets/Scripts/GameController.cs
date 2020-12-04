using System;
using DefaultNamespace.UI;
using PlaygroundGrid;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] GridController _gridController = default;
        [SerializeField] private InterfaceController _interfaceController = default;

        [Inject] private TetrinoConfig _tetrinoConfig = default;
        [Inject] private SpeedController _speedController = default;
        [Inject] private TetrinoController.Factory _tetrinoFactory;
        [SerializeField] private AudioManager _audioManager = default;
        
         private void Start()
         {
             CreatTetrino();
         }

         public GameObject CreatTetrino()
         {
             var tetrino = _tetrinoFactory.Create(_speedController.fallSpeed, this);
             tetrino.transform.position = _gridController.GetSpawnPoint();

             return tetrino.gameObject;
         }

         public void PauseGame()
         {
             _audioManager.PlayPause();
             _interfaceController.ShowPausePanel();
             _speedController.StopMoving();
         }

         public void ContinueGame()
         {
             _audioManager.PlayContinueGame();
             _interfaceController.ClosePausePanel();
             _speedController.ContinueMoving();
         }

         private void RestartGame(GameObject go)
         {
             _audioManager.PlayNewGame();
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }

         public void CheckDrop(TetrinoController tetrinoController)
         {
             _gridController.ClearRow();
             var pref = CreatTetrino();

             if (_gridController.CheckIsAboveGrid(tetrinoController))
             {
                 RestartGame(pref);
             }
         }
    }
}