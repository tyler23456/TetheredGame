using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace TG.UserPlayer
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : Character, ICharacter
    {
        [SerializeField] protected Controls controls;
        CharacterController controller;

        protected new void Start()
        {
            //if (!IsOwner)
                //return;

            base.Start();
            
            controller = GetComponent<CharacterController>();
        }

        protected new void Update()
        {
            //temporary
            //if (!IsOwner)
                //return;
            //temporary


            
            base.Update();

            //controls.Update();
            
        }
    }
}