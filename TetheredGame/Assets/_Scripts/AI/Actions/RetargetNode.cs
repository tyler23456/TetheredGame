using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class RetargetNode : ActionNode
    {
        protected override void OnStart()
        {
            state = State.Running;
        }

        

        protected override State OnUpdate()
        {



            return state;
        }

        protected override void OnStop() { }
    }
}