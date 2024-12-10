using UnityEngine;

namespace EconomySimulation
{
    public static class Bootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Run()
        {
            Application.targetFrameRate = 60;
        }
    }
}