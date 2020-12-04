using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "TetrisConfigs/AudioConfig", order = 0)]
public class AudioConfig : ScriptableObject
{
    public AudioClip rotateClip;
    public AudioClip moveClip;
    public AudioClip pauseClip;
    public AudioClip resumeClip;
    public AudioClip newGameClip;
}
