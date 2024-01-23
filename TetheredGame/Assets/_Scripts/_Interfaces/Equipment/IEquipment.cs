using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment
{
    GameObject getEquipment { get; }
    string getAnimatorParameter { get; }
    Sprite getIcon { get; }
    void Use(GameObject user);
}
