using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace TG.XRToolkit
{
    public class XRGrabInteractableTwoAttach : XRGrabInteractable
    {
        [SerializeField] Transform leftAttachTransform;
        [SerializeField] Transform rightAttachTransfrom;

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (args.interactableObject.transform.CompareTag("Left Hand"))
            {
                attachTransform = leftAttachTransform;
            }
            else if (args.interactableObject.transform.CompareTag("Right Hand"))
            {
                attachTransform = rightAttachTransfrom;
            }

            base.OnSelectEntered(args);
        }
    }
}