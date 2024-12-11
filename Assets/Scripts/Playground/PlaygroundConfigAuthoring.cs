using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace EconomySimulation
{
    public struct PlaygroundConfig : IComponentData
    {
        public Entity WorkerPrefab;
        public float2 GridSize;
        public float2 GridStep;
        public float2 GridCenter;
    }
    
    public class PlaygroundConfigAuthoring : MonoBehaviour
    {
        public GameObject workerPrefab;
        public float2 gridSize;
        public float2 gridStep;
        public float2 gridCenter;

        public class Baker : Baker<PlaygroundConfigAuthoring>
        {
            public override void Bake(PlaygroundConfigAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                
                AddComponent(entity, new PlaygroundConfig
                {
                    WorkerPrefab = GetEntity(authoring.workerPrefab, TransformUsageFlags.Dynamic),
                    GridSize = authoring.gridSize,
                    GridStep = authoring.gridStep,
                    GridCenter = authoring.gridCenter
                });
            }
        }
    }
}