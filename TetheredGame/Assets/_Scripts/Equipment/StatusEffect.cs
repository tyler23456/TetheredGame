using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Equipment
{
    [CreateAssetMenu(fileName = "New Status Effect", menuName = "Status Effect")]
    public class StatusEffect : ItemBase, IEquipment
    {
        [SerializeField] string attribute = "default";
        [SerializeField] float offset = 1f;

        public override void Initialize()
        {

        }

        public override void Use(GameObject user)
        {
            ICharacter character = user.GetComponent<ICharacter>();
            //character.getStats.AddEffect(getName, attribute, offset);
        }
    }
}