using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : UserNode
{
    protected override State OnUpdate()
    {
        if (state == State.Success || state == State.Running)
            return children[0].Update();
        else
            return state;
    }

    public override UserNode Clone()
    {
        DecoratorNode node = Instantiate(this);
        node.children = children.ConvertAll(c => c.Clone());
        return node;
    }
}
