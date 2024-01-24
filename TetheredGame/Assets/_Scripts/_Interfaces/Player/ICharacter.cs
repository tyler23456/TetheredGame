using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    string tag { get; set; }
    bool enabled { get; set; }


    Vector3 getPosition { get; }
    Vector3 getForward { get; }
    IMovement getMovement { get; }
    IOrientation getOrientation { get; }
    IInventory getKeyItems { get; }
    IInventory getEquipment { get; }
    IAnimations getAnimations { get; }

    void SpawnEffectByName(string name);
}
    
    