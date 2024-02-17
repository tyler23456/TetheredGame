using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IStats
{
    float GetAttribute(string attributeName);
    void OffsetAttribute(string attributeName, int offsetAmount);
    void AddOnValueChangedTo(string attributeName, Action<int> action);
}
