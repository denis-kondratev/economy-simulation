using UnityEngine;

namespace EconomicSimulation
{
    public class Playground : MonoBehaviour
    {
        public Worker worker;
        public Vector2 size;
        public Vector2 step;

        private void Awake()
        {
            CreateWorkers();
        }

        void CreateWorkers()
        {
            var workerCount = size / step;
            var offset = size / 2 - step / 2;
            var startPosition =  transform.position - new Vector3(offset.x, transform.position.y, offset.y);

            for (var i = 0; i < workerCount.x; i++)
            {
                for (var j = 0; j < workerCount.y; j++)
                {
                    var position = startPosition + new Vector3(i * step.x, 0, j * step.y);
                    Instantiate(worker, position, Quaternion.identity);
                }
            }
        }
    }
}