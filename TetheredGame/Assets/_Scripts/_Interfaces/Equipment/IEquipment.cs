using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipment
{
    string getName { get; }
    Object getEquipment { get; }
    string getAnimatorParameter { get; }
    Sprite getIcon { get; }
    void Initialize();
    void Use(GameObject user);
}
