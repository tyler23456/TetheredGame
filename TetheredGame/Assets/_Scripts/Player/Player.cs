using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Player
{
    public class Player : Character
    {
        protected new void Start()
        {
            if (!IsOwner)
                return;

            base.Start();
        }

        protected new void Update()
        {
            if (!IsOwner)
                return;

            base.Update();
        }
    }
}