using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class StopMovementNode : WaitNode
    {
        protected override void OnStart()
        {
            state = State.Running;
            board.user.getAnimation.SetVelocity(Vector3.zero);
        } 

        protected override State OnUpdate()
        {
            return base.OnUpdate();
        }

        protected override void OnStop() { }
    }
}