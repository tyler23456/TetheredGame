using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Stats : IStats
    {
        Dictionary<string, int> attributes = new Dictionary<string, int>();
        Dictionary<string, Action<int>> events = new Dictionary<string, Action<int>>();
        Dictionary<string, int> maxAttributes = new Dictionary<string, int>();

        float timeAccumulator = 0;
        const float TIME_DURATION = 5f;

        public void Initialize()
        {
            maxAttributes.Add("Sanity", 100);
            maxAttributes.Add("Thrill", 100);
            maxAttributes.Add("Lives", 9);

            attributes.Add("Sanity", 100);
            attributes.Add("Thrill", 0);
            attributes.Add("Lives", 1);
        }

        public void Update()
        {
            if (Time.time - timeAccumulator < TIME_DURATION)
                return;

            timeAccumulator = Time.time;

            OffsetAttribute("Sanity", 1);
            OffsetAttribute("Thrill", -1);

        }

        public float GetAttribute(string attributeName)
        {
            return attributes[attributeName];
        }

        public void OffsetAttribute(string attributeName, int offsetAmount)
        {
            attributes[attributeName] += offsetAmount;
            attributes[attributeName] = Mathf.Clamp(attributes[attributeName], 0, maxAttributes[attributeName]);

            if (!events.ContainsKey(attributeName))
                return;

            events[attributeName].Invoke(attributes[attributeName]);
        }

        public void AddOnValueChangedTo(string attributeName, Action<int> action)
        {
            events.Add(attributeName, action);
        }
    }
}