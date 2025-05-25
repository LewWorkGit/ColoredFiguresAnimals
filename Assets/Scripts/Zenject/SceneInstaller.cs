using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private FigureSpawner figureSpawner;
    [SerializeField] private ActionBar actionBar;
    [SerializeField] private GameOverView gameOver;
    public override void InstallBindings()
    {
        Container.Bind<FigureSpawner>().
            FromInstance(figureSpawner).
            AsSingle();

        Container.Bind<ActionBar>().
           FromInstance(actionBar).
           AsSingle();

        Container.Bind<GameOverView>().
          FromInstance(gameOver).
          AsSingle();
    }
}
