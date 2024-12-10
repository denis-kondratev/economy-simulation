using Unity.Entities;
using UnityEngine;

namespace EconomySimulation.Playground
{
    public struct PlaygroundConfig : IComponentData
    {
        public Entity SloggerPrefab;
    }
    
    public class PlaygroundConfigAuthoring : MonoBehaviour
    {
        public GameObject sloggerPrefab;

        public class Baker : Baker<PlaygroundConfigAuthoring>
        {
            public override void Bake(PlaygroundConfigAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new PlaygroundConfig
                {
                    SloggerPrefab = GetEntity(authoring.sloggerPrefab, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}