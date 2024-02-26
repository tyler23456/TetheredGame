using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Equipped : IEquipped
    {
        IFactory factory;

        [SerializeField] GameObject user;
        [SerializeField] Transform leftHandSlot;
        [SerializeField] Transform rightHandSlot;

        public bool isLeftHandOccupied => leftHandSlot.childCount > 0;
        public bool isRightHandOccupied => rightHandSlot.childCount > 0;

        public void Initialize(IFactory factory)
        {
            this.factory = factory;
        }

        public void GrabLeftHandEquipment(Transform equipment)
        {
            if (leftHandSlot.childCount > 0)
                leftHandSlot.GetChild(0).parent = null;

            equipment.parent = leftHandSlot;
            equipment.transform.localPosition = Vector3.zero;
            equipment.transform.localEulerAngles = Vector3.zero;
        }

        public void GrabRightHandEquipment(Transform equipment)
        {
            if (rightHandSlot.childCount > 0)
                rightHandSlot.GetChild(0).parent = null;

            equipment.parent = rightHandSlot;
            equipment.transform.localPosition = Vector3.zero;
            equipment.transform.localEulerAngles = Vector3.zero;
        }

        public void LeftHandInteract()
        {
            leftHandSlot.GetChild(0).GetComponent<IActivator>().LeftHandInteract();
        }

        public void RightHandInteract()
        {
            rightHandSlot.GetChild(0).GetComponent<IActivator>().RightHandInteract();
        }

        public void DropLeftHandEquipment()
        {
            if (leftHandSlot.childCount == 0)
                return;

            leftHandSlot.GetChild(0).parent = null;
        }

        public void DropRightHandEquipment()
        {
            if (rightHandSlot.childCount == 0)
                return;

            rightHandSlot.GetChild(0).parent = null;
        }

        public bool LeftHandEquals(Transform equipment)
        {
            return leftHandSlot.childCount > 0 && leftHandSlot.GetChild(0).Equals(equipment);
        }

        public bool RightHandEquals(Transform equipment)
        {
            return rightHandSlot.childCount > 0 && rightHandSlot.GetChild(0).Equals(equipment);
        }
    }
}