using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class RigidbodyActivator : ActivatorBase, IActivator
    {
        [SerializeField] Rigidbody userRigidbody;
        [SerializeField] float force = 5f;

        void IActivator.Activate()
        {

            Vector3 direction = (transform.position - userPosition).normalized;
            userRigidbody.AddForce(direction * force + Vector3.up * 2f, ForceMode.Impulse);
        }

        void IActivator.Deactivate()
        {

        }
    }
}
