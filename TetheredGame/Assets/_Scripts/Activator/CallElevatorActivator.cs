using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class CallElevatorActivator : ActivatorBase, IActivator
    {
        [SerializeField] int floor;
        [SerializeField] float elevation;
        [SerializeField] ElevatorActivator elevatorActivator;
        [SerializeField] AudioSource audioSource;

        public int getFloor => floor;
        public float getElevation => elevation;

        public override void Activate()
        {
            
        }
    }
}