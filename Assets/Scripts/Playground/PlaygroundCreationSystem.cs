using Unity.Burst;
using Unity.Entities;

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
            state.EntityManager.Instantiate(config.SloggerPrefab);
        }
    }
}