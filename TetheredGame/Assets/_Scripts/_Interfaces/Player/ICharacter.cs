using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public interface ICharacter
{
    static ReadOnlyCollection<string> names = new ReadOnlyCollection<string>(new string[5] { "Larry", "Isaac", "Moris", "Denise", "Clair" });

    string tag { get; set; }
    bool enabled { get; set; }

    Transform getTransform { get; }
    GameObject getGameObject { get; }
    Collider getCollider { get; }
    Vector3 getCenter { get; }
    Vector3 getPosition { get; }
    Vector3 getForward { get; }
    IMovement getMovement { get; }
    IOrientation getOrientation { get; }
    IAnimation getAnimation { get; }
    IStats getStats { get; }
    IStatEffects getStatEffects { get; }
    IEquipped getEquipped { get; }

    bool isVisible { get; }

    void SpawnEffectByName(string name);
}
    
    