using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class CursedItemActivator : ActivatorBase, IActivator
    {
        public override void LeftHandInteract()
        {
            user.getEquipped.GrabLeftHandEquipment(transform);
            //factory.effects["CursedItem"].Use(user.getGameObject);
        }

        public override void RightHandInteract()
        {
            user.getEquipped.GrabRightHandEquipment(transform);
            //factory.effects["CursedItem"].Use(user.getGameObject);
        }
    }
}
