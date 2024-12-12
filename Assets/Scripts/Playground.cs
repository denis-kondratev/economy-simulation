using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EconomicSimulation
{
    public class Playground : MonoBehaviour
    {
        public Worker worker;
        public Vector2 size;
        public Vector2 step;
        public Product[] products;
        public Vector2 workerCapacityRange;
        public float dayLength = 60;

        private Worker[] _workers;
        private float _nextDayTime;

        private void Awake()
        {
            CreateWorkers();
        }

        void CreateWorkers()
        {
            var workerCount = size / step;
            var offset = size / 2 - step / 2;
            var startPosition =  transform.position - new Vector3(offset.x, transform.position.y, offset.y);
            _workers = new Worker[(int)(workerCount.x * workerCount.y)];
            var index = 0;

            for (var i = 0; i < workerCount.x; i++)
            {
                for (var j = 0; j < workerCount.y; j++)
                {
                    var position = startPosition + new Vector3(i * step.x, 0, j * step.y);
                    var newWorker = Instantiate(worker, position, Quaternion.identity);
                    newWorker.Capacity = Random.Range(workerCapacityRange.x, workerCapacityRange.y);
                    newWorker.Products = products;
                    _workers[index++] = newWorker;
                }
            }
        }

        void Update()
        {
            Array.ForEach(_workers, w => w.UpdateWorker(Time.time, Time.deltaTime));
            
            if (_nextDayTime < Time.time)
            {
                _nextDayTime = Time.time + dayLength;
                Array.ForEach(_workers, w => w.EndDay());
            }
        }
    }
}