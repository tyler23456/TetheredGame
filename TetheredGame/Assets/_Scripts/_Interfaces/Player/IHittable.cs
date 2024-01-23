using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    string tag { get; set; }
    bool enabled { get; set; }

    IPosition getPosition { get; }
    IRotation getRotation { get; }
    IInventory getKeyItems { get; }
    IInventory getEquipment { get; }
    IAnimations getAnimations { get; }

    void SpawnEffectByName(string name);
}
    
    