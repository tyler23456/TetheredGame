using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class ActivatorBase : MonoBehaviour
    {
        public Vector3 userPosition { get; set; } = Vector3.zero;
        public Vector3 impactPosition { get; set; } = Vector3.zero;
        public float forceMultiplier { get; set; } = 1f;
    }
}
