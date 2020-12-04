using System;
using TMPro;
using UnityEngine;
using UnityEditor;
using Zenject;

namespace DefaultNamespace.UI
{
    public class InterfaceController : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel = default;
        [SerializeField] private TMP_Text score = default;
        [SerializeField] private TMP_Text level = default;
        [SerializeField] private TMP_Text lines = default;

        [Inject] private StatsController _statsController;
        [Inject] private LevelController _levelController;

        [Inject] private SignalBus _signalBus;

        private void Awake()
        {
            _signalBus.Subscribe<ChangedStatsSignal>(x =>
            {
                score.text = x.score.ToString();
                lines.text = $"lines {x.lines}";
            });
            
            _signalBus.Subscribe<ChangedLevelSignal>(x =>
            {
                level.text = $"level {x.level}";
            });
        }

        public void ShowPausePanel()
        {
            pausePanel.SetActive(true);
        }

        public void ClosePausePanel()
        {
            pausePanel.SetActive(false);
        }
    }
}