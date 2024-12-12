using UnityEngine;

namespace EconomicSimulation
{
    [CreateAssetMenu(fileName = "Product", menuName = "Simulation", order = 0)]
    public class Product : ScriptableObject
    {
        public string productName;
        public float productionEffort;
        public float happiness;
        public Need need;
    }
}