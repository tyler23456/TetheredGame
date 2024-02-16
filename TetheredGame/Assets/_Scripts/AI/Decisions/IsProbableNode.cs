using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class IsProbableNode : DecoratorNode
    {
        [SerializeField] float normalizedProbability = 0.1f;

        protected override void OnStart()
        {
            state = State.Running;
        }

        protected override State OnUpdate()
        {
            if (Random.Range(0f, 1f) >= normalizedProbability)
                state = State.Running;
            else
                state = State.Failure;

            return base.OnUpdate();
        }

        protected override void OnStop() { }
    }
}