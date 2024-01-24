using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : Character
    {
        [SerializeField] protected Controls controls;

        CharacterController controller;

        protected new void Start()
        {
            if (!IsOwner)
                return;

            base.Start();

            controller = GetComponent<CharacterController>();
            position.onMove = (changeInPosition) => controller.Move(changeInPosition);

            controls.moveUp = () => position.Add(Vector3.forward * 5f);
            controls.moveDown = () => position.Add(Vector3.back * 5f);
            controls.moveLeft = () => position.Add(Vector3.left * 5f);
            controls.moveRight = () => position.Add(Vector3.right * 5f);
        }

        protected new void Update()
        {
            if (!IsOwner)
                return;

            base.Update();

            controls.Update();
        }
    }
}