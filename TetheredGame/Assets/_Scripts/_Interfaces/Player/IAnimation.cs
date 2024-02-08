using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    Transform getRoot { get; }
    void SetTrigger(string parameterName);
    void SetBool(string parameterName, bool value);
    void SetSpeed(float value);
    float GetSpeed();
    Vector3 GetVelocity();
    void AddVelocity(Vector3 velocity);
    void SetVelocity(Vector3 velocity);
    void AddVelocityAndSetSpeed(Vector3 velocity, float speed);
}
