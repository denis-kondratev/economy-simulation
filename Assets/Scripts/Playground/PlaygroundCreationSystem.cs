using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace EconomySimulation.Playground
{
    public partial struct PlaygroundCreationSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (SystemAPI.TryGetSingletonEntity<PlaygroundConfig>(out var configEntity))
            {
                var config = SystemAPI.GetComponent<PlaygroundConfig>(configEntity);
                CreatePlayground(ref state, ref config);
                state.EntityManager.DestroyEntity(configEntity);
            }
        }

        private void CreatePlayground(ref SystemState state, ref PlaygroundConfig config)
        {
            var min = config.GridCenter - config.GridSize / 2;
            var max = config.GridCenter + config.GridSize / 2;

            for (var x = min.x; x <= max.x; x += config.GridStep.x)
            {
                for (var y = min.y; y <= max.y; y += config.GridStep.y)
                {
                    var slogger = state.EntityManager.Instantiate(config.SloggerPrefab);
                    SystemAPI.SetComponent(slogger, LocalTransform.FromPosition(x, 0, y));
                }
            }
        }
    }
}