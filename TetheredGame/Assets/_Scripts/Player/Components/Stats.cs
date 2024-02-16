using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Stats : IStats
    {
        Dictionary<string, float> attributes = new Dictionary<string, float>();
        Dictionary<string, float> staticAttributes = new Dictionary<string, float>();
        Dictionary<string, (string, float)> effects = new Dictionary<string, (string, float)>();

        public void Initialize()
        {
            staticAttributes.Add("Sanity", 1f);
            staticAttributes.Add("Adrenaline", 1f);
            staticAttributes.Add("Speed", 1f);
            staticAttributes.Add("Lives", 1f);
            Refresh();
        }
        
        public float GetAttribute(string attributeName)
        {
            return attributes[attributeName];
        }

        void Refresh()
        {
            attributes.Clear();
            foreach (KeyValuePair<string, float> staticAttribute in staticAttributes)
                attributes.Add(staticAttribute.Key, staticAttribute.Value);

            foreach (KeyValuePair<string, (string, float)> effect in effects)
                attributes.Add(effect.Value.Item1, effect.Value.Item2);
        }

        public void AddEffect(string effectName, string attributeName, float offset)
        {
            effects.Add(effectName, (attributeName, offset));
            Refresh();
        }

        public void RemoveEffect(string effectName)
        {
            effects.Remove(effectName);
            Refresh();
        }
    }
}