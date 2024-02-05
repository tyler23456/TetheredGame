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
            if (!GameObject.Find("/DontDestroyOnLoad").GetComponent<ITarget>().hasTarget)
                return State.Failure;

            board.agent.destination = GameObject.Find("/DontDestroyOnLoad").GetComponent<ITarget>().getPosition;
            //board.agent.Move(board.agent.desiredVelocity);

            return state;
        }

        protected override void OnStop()
        {

        }
    }
}