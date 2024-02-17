using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class ScareNode : WaitNode
    {
        protected override void OnStart()
        {
            state = State.Running;
            board.jumpScare.Scare();
        }

        protected override State OnUpdate()
        {
            state = base.Update();
            return state;
        }

        protected override void OnStop() { }
    }
}