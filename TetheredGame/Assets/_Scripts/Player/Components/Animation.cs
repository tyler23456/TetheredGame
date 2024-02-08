using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Animation : IAnimation
    {
        public Transform getRoot => throw new System.NotImplementedException();
        [SerializeField] Animator animator;

        public void AddVelocity(Vector3 velocity)
        {
            animator.SetFloat("velocityX", animator.GetFloat("velocityX") + velocity.x);
            animator.SetFloat("velocityZ", animator.GetFloat("velocityZ") + velocity.z);
        }

        public void AddVelocityAndSetSpeed(Vector3 velocity, float speed)
        {
            throw new System.NotImplementedException();
        }

        public Vector3 GetVelocity()
        {
            throw new System.NotImplementedException();
        }

        public void SetBool(string parameterName, bool value)
        {
            throw new System.NotImplementedException();
        }

        public void SetSpeed(float value)
        {
            animator.SetFloat("speed", value);
        }

        public float GetSpeed()
        {
            return animator.GetFloat("speed");
        }

        public void SetTrigger(string parameterName)
        {
            throw new System.NotImplementedException();
        }

        public void SetVelocity(Vector3 velocity)
        {
            animator.SetFloat("velocityX", velocity.x);
            animator.SetFloat("velocityZ", velocity.z);
        }
    }
}