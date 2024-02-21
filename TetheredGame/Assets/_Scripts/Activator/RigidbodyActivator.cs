using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class RigidbodyActivator : ActivatorBase, IActivator
    {
        const float DISTANCE_MULTIPLIER = 1.5f;

        [SerializeField] AudioSource audioSource;
        [SerializeField] Rigidbody userRigidbody;
        [SerializeField] float force = 5f;

        void IActivator.Activate()
        {
            float distance = Vector3.Distance(transform.position, userPosition) * DISTANCE_MULTIPLIER;
            Vector3 direction = (transform.position - impactPosition).normalized;
            userRigidbody.AddForce(direction * force * forceMultiplier + Vector3.up * 2f, ForceMode.Impulse);
        }

        void IActivator.Deactivate() { }

        void OnCollisionEnter(Collision collision)
        {
            if (audioSource == null)
                return;


            if (collision.relativeVelocity.magnitude > 2f)
            {
                PlayRandomHardSFX();
            }             
            else if (collision.relativeVelocity.magnitude > 1f)
            {
                PlayRandomSoftSFX();
            }             
        }

        public void PlayRandomSoftSFX()
        {
            audioSource.Play();
        }

        public void PlayRandomHardSFX()
        {
            audioSource.Play();
        }
    }
}
