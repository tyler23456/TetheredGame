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
        [SerializeField] protected Aim aim;
        
        CharacterController controller;       

        protected new void Start()
        {
            //if (!IsOwner)
                //return;

            base.Start();   
            controller = GetComponent<CharacterController>();

            //-----------------------------------------
            GameObject.Find("/DontDestroyOnLoad").GetComponent<IGlobal>().SetTarget(this);
            //-----------------------------------------
        }

        protected void FixedUpdate()
        {
            
        }

        protected new void Update()
        {
            //temporary
            //if (!IsOwner)
                //return;
            //temporary



            
            base.Update();
            aim.Update();

            //controls.Update();

        }

        protected void LateUpdate()
        {
            
        }
    }
}