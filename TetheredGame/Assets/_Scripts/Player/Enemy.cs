using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    public class Enemy : Character, ICharacter
    {
        protected new void Start()
        {
            //if (!IsOwner)
                //return;

            base.Start();
            GetComponent<Animator>().speed = 0.6f;
        }

        protected new void Update()
        {
            //if (!IsOwner)
                //return;

            base.Update();
        }
    }
}