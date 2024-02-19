using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class DoorActivator : ActivatorBase, IActivator
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] Animator animator;

        void IActivator.Activate()
        {
            audioSource.Play();
            animator.SetTrigger("Activate");
        }

        void IActivator.Deactivate()
        {
            
        }
    }
}