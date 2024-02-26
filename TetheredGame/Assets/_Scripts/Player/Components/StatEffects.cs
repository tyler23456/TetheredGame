using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class StatEffects : IStatEffects
    {
        [SerializeField] Transform statEffects;
        public void Add(Transform effect)
        {
            effect.parent = statEffects;
        }

        public void Remove(string effectName)
        {
            foreach (Transform child in statEffects)
                if (child.name == effectName)
                {
                    GameObject.Destroy(child.gameObject);
                    break;
                }
        }
    }
}