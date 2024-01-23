using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Equipment
{
    public abstract class ItemBase : ScriptableObject
    {
        [SerializeField] Sprite icon;

        public Sprite getIcon { get; }

        public abstract void Use(GameObject user);
    }
}