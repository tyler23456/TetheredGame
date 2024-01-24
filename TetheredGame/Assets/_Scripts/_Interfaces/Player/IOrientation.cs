using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOrientation
{
    void SetAxes(bool xAxis, bool yAxis, bool zAxis);
    void Add(Vector3 eulerAnglesOffset);
    void Forward(Vector3 forward);
    void Forward(Vector3 relativeForward, Vector3 localForward);
}
