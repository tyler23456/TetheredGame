using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.AI
{
    public class ActivateNearbyNode : ActionNode
    {
        [SerializeField] string tag = "Untagged";
        [SerializeField] float radius = 10f;

        Collider[] colliders;
        Collider collider;
        IActivator activator;

        protected override void OnStart()
        {
            state = State.Running;
        }

        protected override State OnUpdate()
        {
            colliders = Physics.OverlapSphere(board.user.getCenter, radius);

            if (colliders.Length == 0)
            {
                state = State.Failure;
                return state;
            }

            collider = colliders[Random.Range(0, colliders.Length)];
            activator = collider.GetComponent<IActivator>();

            if (activator == null || collider.tag != tag)
            {
                state = State.Failure;
                return state;
            }

            activator.Activate();

            return state;
        }

        protected override void OnStop() { }
    }
}