using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    public float GetAttribute(string attributeName);
    public void AddEffect(string effectName, string attributeName, float offset);
    public void RemoveEffect(string effectName);
}
