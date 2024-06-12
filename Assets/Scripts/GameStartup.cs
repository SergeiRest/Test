using Leopotam.Ecs;
using Scripts.EntityReference.Systems;
using Scripts.Items;
using Scripts.Items.ItemsData;
using Scripts.Items.Systems;
using Scripts.Joysitck.Components;
using Scripts.Joysitck.Systems;
using Scripts.Player.Systems;
using UnityEngine;
using Voody.UniLeo;

namespace Scripts
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private ItemsData _itemsData;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            _systems.ConvertScene();
            
            AddInjections();
            AddSystems();
            AddOneFrames();
            
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void AddSystems()
        {
            _systems

                .Add(new EntityReferenceInitializerSystem())

                .Add(new StorageSlotsChecker())
                .Add(new FillTimer())
                .Add(new AddItemSystem())

                #region Joystick

                .Add(new JoystickHandlePositionCalculator())
                .Add(new JoystickViewUpdate())

                #endregion

                #region Player

                .Add(new UpdateDirectionSystem())
                .Add(new PlayerMovementSystem())
                .Add(new PlayerRotationSystem())

                #endregion

                .Add(new GiveItemSystem())
                .Add(new ItemMoveToStackSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(_itemsData);
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<PointerDownSignal>()
                .OneFrame<PointerUpSignal>()
                .OneFrame<DragSignal>()
                .OneFrame<UpdateAfterDrag>();
        }
    }
}