using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    public class Enemy : Character, ICharacter
    {
        Animator animator;

        protected new void Start()
        {
            //if (!IsOwner)
                //return;

            base.Start();
            //animator = GetComponent<Animator>();
            //animator.speed = 0.6f;

            //stats.AddOnValueChangedTo("Thrill", (value) => animator.speed = value / 100f * ANIMATOR_SPEED_MULTIPLIER);
        }

        protected new void Update()
        {
            //if (!IsOwner)
                //return;

            base.Update();
        }
    }
}