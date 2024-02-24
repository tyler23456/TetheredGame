using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class LightActivator : ActivatorBase, IActivator
    {
        public static bool allLightsVisibility { get; set; } = true;

        [SerializeField] List<Light> lights;
        [SerializeField] AudioSource audioSource;

        Material material;
        string emissionName = "_EmissionColor";


        void Start()
        {
            if (allLightsVisibility)
                return;

            material = GetComponent<Renderer>().material;
            material.SetColor(emissionName, Color.black);

            foreach (Light light in lights)          
                light.enabled = false; 
        }

        public override void Activate()
        {   
            foreach (Light light in lights)
            {
                //need to rework this
                material = GetComponent<Renderer>().material;
                if (light.enabled)
                    material.SetColor(emissionName, Color.black);
                else
                    material.SetColor(emissionName, Color.white);

                light.enabled = !light.enabled;
            }
            

            if (audioSource == null)
                return;

            audioSource.Play();
        }
    }
}
