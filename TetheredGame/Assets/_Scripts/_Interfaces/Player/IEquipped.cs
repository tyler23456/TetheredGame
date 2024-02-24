using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipped
{
    bool isLeftHandOccupied { get; }
    bool isRightHandOccupied { get; }

    void GrabLeftHandEquipment(Transform equipment);
    void GrabRightHandEquipment(Transform equipment);
    void RightHandInteract();
    void LeftHandInteract();
    void DropLeftHandEquipment();
    void DropRightHandEquipment();
}
