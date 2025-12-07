using UnityEngine;
using Zenject;

public class GameBinding : MonoInstaller
{
    [SerializeField] FoodMediator foodMediator;
    [SerializeField] GameClock gameClock;
    [SerializeField] TripulantesPool pool;
    [Header("M")]
    [SerializeField] FishBank bankPrototype;

    public override void InstallBindings()
    {
        Container.Bind<FoodMediator>().FromInstance(foodMediator).AsSingle().NonLazy();
        Container.Bind<GameClock>().FromInstance(gameClock).AsSingle().NonLazy();
        Container.Bind<TripulantesPool>().FromInstance(pool).AsSingle().NonLazy();
        Container.BindFactory<FishBank, FishBank.Factory>().FromComponentInNewPrefab(bankPrototype);
    }
}
