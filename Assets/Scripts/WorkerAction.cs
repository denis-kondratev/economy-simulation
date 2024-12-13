namespace EconomicSimulation
{
    public abstract class WorkerAction
    {
        public float StartTime { get; }
        public float EndTime { get; }
        public abstract string Name { get; }

        protected WorkerAction(float startTime, float endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}