using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Effects
{
    public class BanishHellspawn : EffectsBase
    {
        protected override void Start()
        {
            foreach (Transform child in global.getSceneEffects)
                if (child.name.Contains("Trap"))
                    Destroy(child);

            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}