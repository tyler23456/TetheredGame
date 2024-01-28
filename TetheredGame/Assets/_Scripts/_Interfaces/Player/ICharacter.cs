using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public interface ICharacter
{
    static ReadOnlyCollection<string> names = new ReadOnlyCollection<string>(new string[5] { "Larry", "Isaac", "Moris", "Denise", "Clair" });

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
    
    