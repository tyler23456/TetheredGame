using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TG.Independent
{
    [CreateAssetMenu(fileName = "NewWeightedList", menuName = "WeightedList")]
    public class WeightedList : ScriptableObject
    {
        [SerializeField] List<WeightedItem> weightedItems;

        public List<Object> items = new List<Object>();
        public List<float> weights = new List<float>();

        public Object GetItem()
        {
            return WeightedDecision.Generate(items, weights);
        }

        public void Awake()
        {
            foreach (WeightedItem weightedItem in weightedItems)
            {
                items.Add(weightedItem.getItem);
                weights.Add(weightedItem.getWeight);
            }
        }

        [System.Serializable]
        public class WeightedItem
        {
            [SerializeField] Object item;
            [SerializeField] float weight;

            public Object getItem => item;
            public float getWeight => weight;
        }

        public static class WeightedDecision
        {
            static float weightSum = 0f;

            public static T Generate<T>(List<T> decisions, List<float> weights)
            {
                weightSum = weights.Sum();

                float randomNumber = Random.Range(0f, 1f);

                float weightAccumulator = 0;
                float normalizedWeight;

                for (int i = 0; i <= decisions.Count; i++)
                {
                    normalizedWeight = weights[i] / weightSum;
                    weightAccumulator += normalizedWeight;

                    if (randomNumber <= weightAccumulator)
                        return decisions[i];
                }
                return decisions.Last();
            }
        }
    }
}