using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class ElevatorActivator : ActivatorBase, IActivator
    {
        [SerializeField] AudioSource audioSource;

        List<CallElevatorActivator> calls = new List<CallElevatorActivator>();
        bool isGoingUp = false;

        public override void Activate()
        {
            
        }

        public void Update()
        {
            if (calls.Count == 0)
                return;

            


        }
    }
}