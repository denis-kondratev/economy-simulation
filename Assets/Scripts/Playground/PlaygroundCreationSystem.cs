using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace EconomySimulation
{
    [BurstCompile]
    public partial struct PlaygroundCreationSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<PlaygroundConfig>();
        }
        
        public void OnUpdate(ref SystemState state)
        {
            CreatePlayground(ref state);
            RemoveConfig(ref state);
        }

        private void CreatePlayground(ref SystemState state)
        {
            var config = SystemAPI.GetSingleton<PlaygroundConfig>();
            var min = config.GridCenter - config.GridSize / 2;
            var max = config.GridCenter + config.GridSize / 2;

            for (var x = min.x; x <= max.x; x += config.GridStep.x)
            {
                for (var y = min.y; y <= max.y; y += config.GridStep.y)
                {
                    var worker = state.EntityManager.Instantiate(config.WorkerPrefab);
                    SystemAPI.SetComponent(worker, LocalTransform.FromPosition(x, 0, y));
                    state.EntityManager.SetName(worker, $"Worker {x}:{y}");
                }
            }
        }

        private void RemoveConfig(ref SystemState state)
        {
            var config = SystemAPI.GetSingleton<PlaygroundConfig>();
            state.EntityManager.DestroyEntity(config.WorkerPrefab);
            state.EntityManager.DestroyEntity(SystemAPI.GetSingletonEntity<PlaygroundConfig>());
        }
    }
}