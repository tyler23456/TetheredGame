using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivator
{
    Vector3 userPosition { get; set; }
    void Activate();
    void Deactivate();
}
