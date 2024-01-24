using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TG.Player
{
    [System.Serializable]
    public class Controls
    {
        [HideInInspector] public KeyCode moveUpKey { get; set; } = KeyCode.W;
        [HideInInspector] public KeyCode moveDownKey { get; set; } = KeyCode.S;
        [HideInInspector] public KeyCode moveLeftKey { get; set; } = KeyCode.A;
        [HideInInspector] public KeyCode moveRightKey { get; set; } = KeyCode.D;
        [HideInInspector] public KeyCode pickUpKey { get; set; } = KeyCode.E;

        [HideInInspector] public Action moveUp { get; set; } = () => { };
        [HideInInspector] public Action moveDown { get; set; } = () => { };
        [HideInInspector] public Action moveLeft { get; set; } = () => { };
        [HideInInspector] public Action moveRight { get; set; } = () => { };

        [HideInInspector] public Action pickUp { get; set; } = () => { };

        public void Update()
        {
            if (Input.GetKey(moveUpKey))
                moveUp.Invoke();

            if (Input.GetKey(moveDownKey))
                moveDown.Invoke();

            if (Input.GetKey(moveLeftKey))
                moveLeft.Invoke();

            if (Input.GetKey(moveRightKey))
                moveRight.Invoke();

            if (Input.GetKeyDown(pickUpKey))
                pickUp.Invoke();
        }
    }
}