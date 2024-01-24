using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    bool hasTarget { get; }
    Vector3 getPosition { get; }
    Vector3 getForward { get; }

    void Set(Transform targetTransform);
}
