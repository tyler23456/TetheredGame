using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InViewNode : DecoratorNode
{
    [SerializeField] float activeDistance = 80f;
    [SerializeField] float fieldOfView = 90f;
    [SerializeField] bool useInnactiveDistance = true;
    [SerializeField] float innactiveDistance = 100f;

    bool active = false;

    protected override void OnStart()
    {
        state = State.Running;
    }

    protected override State OnUpdate()
    {
        if (WithinLineOfSight())
            active = true;
        else if (!useInnactiveDistance || useInnactiveDistance && Vector3.Distance(board.user.getCenter, Blackboard.global.target.getCenter) > innactiveDistance)
            active = false;
        
        if (active)
            state = State.Success;
        else
            state = State.Failure;

        return base.OnUpdate();
    }

    protected override void OnStop(){}

    protected bool WithinLineOfSight()
    {
        Vector3 direction = (Blackboard.global.target.getCenter - board.user.getCenter).normalized;
        float dotProduct = Vector3.Dot(board.user.getCenter, direction);

        if (dotProduct < Mathf.Cos(fieldOfView))
            return false;

        if (!Physics.Raycast(board.user.getCenter, direction, out RaycastHit hit, activeDistance) || hit.transform != null && hit.transform.gameObject.name != "Player")
            return false;

        return true;
    }
}
