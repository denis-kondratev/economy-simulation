namespace EconomicSimulation
{
    public class RestAction : WorkerAction
    {
        public override string Name => "rest";

        public RestAction(float startTime, float endTime) : base(startTime, endTime)
        {
            
        }
    }
}