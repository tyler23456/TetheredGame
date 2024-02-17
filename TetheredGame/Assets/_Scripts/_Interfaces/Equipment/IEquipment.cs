using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment
{
    void Awake();
    string getName { get; }
    Object getEquipment { get; }
    string getAnimatorParameter { get; }
    Sprite getIcon { get; }
    void Use(GameObject user);
}
