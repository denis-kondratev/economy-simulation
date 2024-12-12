using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace EconomicSimulation
{
    public class Worker : MonoBehaviour
    {
        public TMP_Text textBlob;
        public float Capacity { get; set; }
        public Product[] Products { get; set; }
        public float Happiness { get; private set; }
        private Dictionary<Product, float> _inventory = new();
        private WorkerAction _action;
        private float _happiness;

        public void UpdateWorker(float now, float deltaTime)
        {
            if (_action != null && _action.EndTime < now)
            {
                FinishAction(now);
            }

            if (_action == null)
            {
                StartProduceAction(now);
            }
        }

        private void StartProduceAction(float now)
        {
            var product = Products[Random.Range(0, Products.Length)];
            var factor = Random.Range(0.8f, 2.5f);
            var duration = product.productionEffort * factor;
            _action = new ProduceAction(now, now + duration, product, Capacity);
            UpdateText();
        }

        private void StartRestAction(float now, float duration)
        {
            _action = new RestAction(now, now + duration);
            UpdateText();
        }

        public void EndDay()
        {
            _happiness = 0;
            var products = _inventory.OrderBy(x => x.Value).Select(x => x.Value).ToList();
            var counter = 1;

            while (products.Count > 0)
            {
                if (products.Count == 1)
                {
                    _happiness += products[0] * counter;
                    break;
                }
                
                var amount = products[^1] - products[^2];
                _happiness += amount * counter;
                counter++;
                products.RemoveAt(products.Count - 1);
            }
            
            UpdateText();
        }

        void FinishAction(float now)
        {
            switch (_action)
            {
                case ProduceAction produceAction:
                    var (product, amount, duration) = produceAction.Finish(now);
                    _inventory[product] = amount;
                    StartRestAction(now, duration);
                    break;
                case RestAction:
                    _action = null;
                    break;
            }
        }

        void UpdateText()
        {
            textBlob.text = $"I happy to {_happiness:F2} and {_action?.Name ?? "do nothing"}";
        }
    }
}