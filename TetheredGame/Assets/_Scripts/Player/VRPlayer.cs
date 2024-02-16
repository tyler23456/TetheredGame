using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [RequireComponent(typeof(CharacterController))]
    public class VRPlayer : Character, ICharacter
    {
        [SerializeField] CharacterController controller;

        protected new void Start()
        {
            //if (!IsOwner)
            //return;

            base.Start();
        }

        protected new void Update()
        {
            //temporary
            //if (!IsOwner)
            //return;
            //temporary

            base.Update();
        }

    }
}