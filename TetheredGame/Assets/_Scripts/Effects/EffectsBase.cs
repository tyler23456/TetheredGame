using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Effects
{
    public abstract class EffectsBase : MonoBehaviour
    {
        protected IFactory factory;
        protected IGlobal global;
        protected ICharacter target;

        virtual protected void Start()
        {
            factory = GameObject.Find("/DontDestroyOnLoad").GetComponent<IFactory>();
            global = GameObject.Find("/DontDestroyOnLoad").GetComponent<IGlobal>();
            if (target.tag == "CharacterEffect")
                target = transform.parent.parent.GetComponent<ICharacter>();
        }

        virtual protected void Update()
        {

        }
    }
}