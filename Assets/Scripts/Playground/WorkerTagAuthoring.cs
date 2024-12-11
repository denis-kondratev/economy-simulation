using Unity.Entities;
using UnityEngine;

namespace EconomySimulation
{
    public struct WorkerTag : IComponentData
    {
        
    }
    
    public class WorkerTagAuthoring : MonoBehaviour
    {
        public class SloggerTagBaker : Baker<WorkerTagAuthoring>
        {
            public override void Bake(WorkerTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<WorkerTag>(entity);
            }
        }
    }
}