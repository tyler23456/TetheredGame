using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Controls : IControls
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
        public Vector3 direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector3 targetPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddVelocity(Vector3 changeInVelocity)
        {
            throw new NotImplementedException();
        }

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

        public void UseAbility()
        {
            throw new NotImplementedException();
        }

        public void UseAim()
        {
            throw new NotImplementedException();
        }

        public void UseDodge()
        {
            throw new NotImplementedException();
        }

        public void UseFreeLook()
        {
            throw new NotImplementedException();
        }

        public void UseJump()
        {
            throw new NotImplementedException();
        }
    }
}