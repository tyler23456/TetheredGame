using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControls
{
    Vector3 direction { get; set; }
    Vector3 targetPosition { get; set; }
    void AddVelocity(Vector3 changeInVelocity);
    void UseDodge();
    void UseJump();
    void UseAim();
    void UseFreeLook();
    void UseAbility();
}
