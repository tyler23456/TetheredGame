using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivator
{
    Vector3 userPosition { get; set; }
    float forceMultiplier { get; set; }
    Vector3 impactPosition { get; set; }
    void Activate();
    void Deactivate();
}
