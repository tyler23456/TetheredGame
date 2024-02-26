using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    void Awake();
    string getName { get; }
    Object getEquipment { get; }
    string getAnimatorParameter { get; }
    Sprite getIcon { get; }
    void Use(GameObject user);
}
