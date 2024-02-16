using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class ChaseNode : ActionNode
    {
        ITarget target;

        protected override void OnStart()
        {
            target = GameObject.Find("/DontDestroyOnLoad").GetComponent<ITarget>();
            state = State.Success;
        }

        protected override State OnUpdate()
        {
            if (!target.hasTarget)
                return State.Failure;

            board.user.getAnimation.SetVelocity(Vector3.zero);

            board.agent.destination = target.getPosition;
            board.user.getAnimation.AddVelocity(Vector3.forward);

            board.user.getOrientation.Forward(board.agent.desiredVelocity.normalized);

            return state;
        }

        protected override void OnStop()
        {

        }
    }
}