using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : Character, ICharacter
    {
        [SerializeField] protected Controls controls;

        CharacterController controller;

        protected new void Start()
        {
            if (!IsOwner)
                return;

            base.Start();

            controller = GetComponent<CharacterController>();
            movement.onMove = (changeInPosition) => controller.Move(changeInPosition);

            controls.moveUp = () => movement.Add(Vector3.forward * 5f);
            controls.moveDown = () => movement.Add(Vector3.back * 5f);
            controls.moveLeft = () => movement.Add(Vector3.left * 5f);
            controls.moveRight = () => movement.Add(Vector3.right * 5f);
            controls.pickUp = () => GameObject.Find("/DontDestroyOnLoad").GetComponent<ITarget>().Set(transform);

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