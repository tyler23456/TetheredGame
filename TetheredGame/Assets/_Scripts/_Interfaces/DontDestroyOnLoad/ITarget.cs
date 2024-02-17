using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    bool hasTarget { get; }
    Vector3 getPosition { get; }
    Vector3 getForward { get; }
    ICharacter getCharacter { get; }
    Vector3 getCenter { get; }
    IStats getStats { get; }

    void Set(ICharacter target);
}
