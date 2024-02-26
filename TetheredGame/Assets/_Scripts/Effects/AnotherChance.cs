using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Effects
{
    public class AnotherChance : EffectsBase
    {
        protected override void Start()
        {
            base.Start();
            target.getStats.OffsetAttribute("Lives", 1);
            Destroy(gameObject, 10f);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}