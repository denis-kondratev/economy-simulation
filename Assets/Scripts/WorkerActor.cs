using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace EconomicSimulation
{
    public class WorkerActor : Agent
    {
        public override void OnActionReceived(ActionBuffers actions)
        {
            Debug.Log($"Received action: {actions.ContinuousActions[0]} and {actions.DiscreteActions[0]}");
        }
    }
}