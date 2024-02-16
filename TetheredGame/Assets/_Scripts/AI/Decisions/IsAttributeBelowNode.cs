using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class IsAttributeBelowNode : DecoratorNode
    {
        [SerializeField] string attribute = "Sanity";
        [SerializeField] float threshold = 50f;

        protected override void OnStart()
        {
            state = State.Running;
        }

        protected override State OnUpdate()
        {
            if (board.target.getStats.GetAttribute(attribute) < threshold)
                state = State.Success;
            else
                state = State.Failure;

            return base.OnUpdate();
        }

        protected override void OnStop() { }
    }
}