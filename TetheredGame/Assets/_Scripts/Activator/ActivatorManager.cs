using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class ActivatorManager : MonoBehaviour
    {
        [SerializeField] List<LightActivator> lightActivators;
        [SerializeField] float minDuration = 0.1f;
        [SerializeField] float maxDuration = 1.5f;

        float accumulator;

        // Start is called before the first frame update
        void Start()
        {
            CalculateDuration();
        }

        // Update is called once per frame
        void Update()
        {

            if (Time.time < accumulator)
                return;

            CalculateDuration();

            lightActivators[Random.Range(0, lightActivators.Count)].Activate();
        }

        void CalculateDuration()
        {
            accumulator = Time.time + Random.Range(minDuration, maxDuration);
        }
    }
}