using UnityEngine;

namespace EconomicSimulation
{
    public static class Bootstrap
    {
        [RuntimeInitializeOnLoadMethod]
        public static void Run()
        {
            Application.targetFrameRate = 60;
        }
    }
}