using UnityEngine;
using Zenject;

public class GameBinding : MonoInstaller
{
    [SerializeField] FoodMediator foodMediator;
    [SerializeField] GameClock gameClock;
    [SerializeField] TripulantesPool pool;
    [Header("Factories")]
    [SerializeField] FishBank bankPrototype;
    [SerializeField] Puerto puertoPrototype;
    [SerializeField] CombatIncurtionStarter combatIncurtionPrototype;

    public override void InstallBindings()
    {
        Container.Bind<FoodMediator>().FromInstance(foodMediator).AsSingle().NonLazy();
        Container.Bind<GameClock>().FromInstance(gameClock).AsSingle().NonLazy();
        Container.Bind<TripulantesPool>().FromInstance(pool).AsSingle().NonLazy();
        Container.BindFactory<FishBank, FishBank.Factory>().FromComponentInNewPrefab(bankPrototype);
        Container.BindFactory<Puerto, Puerto.Factory>().FromComponentInNewPrefab(puertoPrototype);
        Container.BindFactory<CombatIncurtionStarter, CombatIncurtionStarter.Factory>().FromComponentInNewPrefab(combatIncurtionPrototype);
    }
}
