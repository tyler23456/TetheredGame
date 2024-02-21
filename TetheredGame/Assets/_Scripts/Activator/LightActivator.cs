using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Activator
{
    public class LightActivator : ActivatorBase, IActivator
    {
        [SerializeField] List<Light> lights;
        [SerializeField] AudioSource audioSource;

        Material material;
        string emissionName = "_EmissionColor";

        public void Activate()
        {   
            foreach (Light light in lights)
            {
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

        void IActivator.Deactivate()
        {

        }
    }
}
