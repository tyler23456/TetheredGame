using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Effects
{
    public class ThrillBoost : EffectsBase
    {
        protected override void Start()
        {
            base.Start();
            target.getStats.OffsetAttribute("Thrill", 40);
            Destroy(gameObject, 10f);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
