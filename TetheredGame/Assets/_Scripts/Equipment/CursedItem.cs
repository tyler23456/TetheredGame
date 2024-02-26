using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Equipment
{
    public class CursedItem : ItemBase, IEffect
    {
        const float ROUND_MULTIPLIER = 10f;
        const float SANITY_MULTIPLIER = 10f;
        const int THRILL_OFFSET = 50;

        public override void Grab(GameObject user)
        {
            ICharacter newTarget = user.GetComponent<ICharacter>();

            global.IncrementRound();
            global.SetTarget(newTarget);

            int roundAdder = (int)(global.round * ROUND_MULTIPLIER);
            int sanityAdder = (int)(global.target.getStats.GetAttribute("Sanity") * SANITY_MULTIPLIER);
            global.enemy.getStats.OffsetAttribute("Thrill", THRILL_OFFSET + roundAdder + sanityAdder);

            global.target.getStats.OffsetAttribute("Thrill", 10);
        }
    }
}