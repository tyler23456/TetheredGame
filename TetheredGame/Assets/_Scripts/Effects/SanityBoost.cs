using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Effects
{
    public class SanityBoost : EffectsBase
    {
        protected override void Start()
        {
            base.Start();
            target.getStats.OffsetAttribute("Sanity", 40);
            Destroy(gameObject, 10f);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
