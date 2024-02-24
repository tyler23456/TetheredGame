using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public abstract class ActivatorBase : MonoBehaviour
    {
        protected IFactory factory;

        public void Start()
        {
            factory = GameObject.Find("/DontDestroyOnLoad").GetComponent<IFactory>();
        }

        public ICharacter user { get; set; } = null;
        public Vector3 userPosition { get; set; } = Vector3.zero;
        public Vector3 impactPosition { get; set; } = Vector3.zero;
        public float forceMultiplier { get; set; } = 1f;

        public virtual void Activate() { }
        public virtual void LeftHandInteract() { }
        public virtual void RightHandInteract() { }
    }
}
