using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Equipment
{

    public abstract class ItemBase : ScriptableObject
    {
        protected static IGlobal global;

        [SerializeField] Sprite icon;

        public Sprite getIcon { get; }
        public string getName => name;
        public Object getEquipment => null;
        public string getAnimatorParameter => "default";

        public void Awake()
        {
            global = GameObject.Find("/DontDestroyOnLoad").GetComponent<IGlobal>();
        }

        public virtual void Use(GameObject user) { }
        public virtual void Grab(GameObject user) { }
    }
}