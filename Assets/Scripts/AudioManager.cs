using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager: MonoBehaviour
    {
        [Inject] private AudioConfig _audioConfig;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayRotate()
        {
            _audioSource.PlayOneShot(_audioConfig.rotateClip);
        }
        public void PlayMove()
        {
            _audioSource.PlayOneShot(_audioConfig.moveClip);
        }
        public void PlayPause()
        {
            _audioSource.PlayOneShot(_audioConfig.pauseClip);
        }
        public void PlayContinueGame()
        {
            _audioSource.PlayOneShot(_audioConfig.resumeClip);
        }
        public void PlayNewGame()
        {
            _audioSource.PlayOneShot(_audioConfig.newGameClip);
        }
    }
}