using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace GT.DontDestroyOnLoad
{
    public class Target : NetworkBehaviour, ITarget
    {
        [SerializeField] Transform targetTransform;

        public bool hasTarget => targetTransform != null;
        public Vector3 getPosition => targetTransform.position;
        public Vector3 getForward => targetTransform.forward;

        public void Set(Transform targetTransform)
        {
            this.targetTransform = targetTransform;
        }
    }
}