using System;
using DefaultNamespace;
using DefaultNamespace.PlaygroundGrid;
using DefaultNamespace.UI;
using PlaygroundGrid;
using UnityEngine;
using Zenject;
using Grid = DefaultNamespace.Grid;
using Random = UnityEngine.Random;

public class GameInstaller : MonoInstaller
{
    [Inject] private TetrinoConfig _tetrinoConfig;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        
        Container.DeclareSignal<TetrinoDroppedSignal>();
        Container.BindSignal<TetrinoDroppedSignal>()
            .ToMethod(x =>
            {
                x.TetrinoController.enabled = false;
                x.GameController.CheckDrop(x.TetrinoController);
            });

        Container.DeclareSignal<ChangedSpeedSignal>();
        Container.DeclareSignal<ChangedLevelSignal>();
        Container.DeclareSignal<ChangedStatsSignal>();

        Container.Bind<Grid>().AsSingle();
        Container.Bind<PositionValidator>().AsSingle();
        Container.Bind<MovementCommands>().AsSingle();
        
        Container.Bind<SpeedController>().AsSingle();
        Container.Bind<StatsController>().AsSingle();
        Container.Bind<LevelController>().AsSingle();

        Container.BindFactory<float, GameController, TetrinoController, TetrinoController.Factory>()
           .FromComponentInNewPrefab(GetRandomTetrinoPrefab());
    }

    private GameObject GetRandomTetrinoPrefab()
    {
        var num = Random.Range(0, _tetrinoConfig.tetrinos.Length);
        return _tetrinoConfig.tetrinos[num];
    }
}