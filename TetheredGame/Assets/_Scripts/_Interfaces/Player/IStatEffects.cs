using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatEffects
{
    void Add(Transform effect);
    void Remove(string effectName);
}
