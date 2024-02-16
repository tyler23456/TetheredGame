using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class IsObservedNode : DecoratorNode
    {
        protected override void OnStart()
        {       
            state = State.Running;
        }

        protected override State OnUpdate()
        {
            if (board.user.isVisible)
                state = State.Running;
            else
                state = State.Failure;

            return base.OnUpdate();
        }

        protected override void OnStop() { }
    }
}