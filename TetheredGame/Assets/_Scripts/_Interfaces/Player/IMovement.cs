using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    Vector3 gravity { get; set; }
    void Add(Vector3 velocityOffset);
}
