using UnityEngine;
using Zenject;

public class GameBinding : MonoInstaller
{
    [SerializeField] FoodMediator foodMediator;
    [SerializeField] GameClock gameClock;
    [SerializeField] TripulantesPool pool;

    public override void InstallBindings()
    {
        Container.Bind<FoodMediator>().FromInstance(foodMediator).AsSingle().NonLazy();
        Container.Bind<GameClock>().FromInstance(gameClock).AsSingle().NonLazy();
        Container.Bind<TripulantesPool>().FromInstance(pool).AsSingle().NonLazy();
    }
}
