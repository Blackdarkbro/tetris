using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

[CreateAssetMenu(fileName = "ConfigInstaller", menuName = "Installers/ConfigInstaller")]
public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller>
{
    [SerializeField] private TetrinoConfig tetrinoConfig = default;
    [SerializeField] private GridConfig gridConfig = default;
    [SerializeField] private AudioConfig audioConfig = default;
    public override void InstallBindings()
    {
        Container.BindInstance(tetrinoConfig);
        Container.BindInstance(gridConfig);
        Container.BindInstance(audioConfig);
    }
}