using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class HasTargetNode : DecoratorNode
    {
        protected override void OnStart()
        {
            state = State.Running;
        }

        protected override State OnUpdate()
        {
            if (Blackboard.global.target == null)
                state = State.Failure;
            else
                state = State.Success;

            return base.OnUpdate();
        }

        protected override void OnStop() { }
    }
}