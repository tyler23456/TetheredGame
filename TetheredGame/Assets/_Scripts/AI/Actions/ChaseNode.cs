using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class ChaseNode : ActionNode
    {
        protected override void OnStart()
        {
            state = State.Success;
        }

        protected override State OnUpdate()
        {
            if (Blackboard.global.target == null)
                return State.Failure;

            board.user.getAnimation.SetVelocity(Vector3.zero);

            board.agent.destination = Blackboard.global.target.getPosition;
            board.user.getAnimation.AddVelocity(Vector3.forward);

            board.user.getOrientation.Forward(board.agent.desiredVelocity.normalized);

            return state;
        }

        protected override void OnStop()
        {

        }
    }
}