using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class ChaseNode : WaitNode
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

            float speedMultiplier = (board.user.getStats.GetAttribute("Thrill") / 100f) + 1;
            board.user.getAnimation.AddVelocity(Vector3.forward * speedMultiplier);

            board.user.getOrientation.Forward(board.agent.desiredVelocity.normalized);

            return base.OnUpdate();
        }

        protected override void OnStop() { }
    }
}