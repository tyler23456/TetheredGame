using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivator
{
    ICharacter user { get; set; }
    Vector3 userPosition { get; set; }
    float forceMultiplier { get; set; }
    Vector3 impactPosition { get; set; }
    void Activate();
    void LeftHandInteract();
    void RightHandInteract();
}
