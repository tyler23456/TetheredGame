using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GT.DontDestroyOnLoad
{
    public class Target : MonoBehaviour, ITarget
    {
        Transform targetTransform;

        public bool hasTarget => targetTransform != null;
        public Vector3 getPosition => targetTransform.position;
        public Vector3 getForward => targetTransform.forward;

        public void Set(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
        }
    }
}