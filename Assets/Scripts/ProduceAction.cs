namespace EconomicSimulation
{
    public class ProduceAction : WorkerAction
    {
        public Product Product { get; }
        public float Capacity { get; }

        public override string Name => $"produce {Product.productName}";

        public ProduceAction(float startTime, float endTime, Product product, float capacity) : base(startTime, endTime)
        {
            Product = product;
            Capacity = capacity;
        }

        public (Product product, float amount, float duration) Finish(float now)
        {
            var duration = now - StartTime;
            var amount = duration * Capacity / Product.productionEffort;
            return (Product, amount, duration);
        }
    }
}