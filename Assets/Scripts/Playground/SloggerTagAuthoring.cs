using Unity.Entities;
using UnityEngine;

namespace EconomySimulation.Playground
{
    public struct SloggerTag : IComponentData
    {
        
    }
    
    public class SloggerTagAuthoring : MonoBehaviour
    {
        public class SloggerTagBaker : Baker<SloggerTagAuthoring>
        {
            public override void Bake(SloggerTagAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<SloggerTag>(entity);
            }
        }
    }
}