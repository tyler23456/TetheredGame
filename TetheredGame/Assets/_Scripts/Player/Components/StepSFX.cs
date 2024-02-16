using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class StepSFX
    {
        [SerializeField] Transform transform;

        public string GetStepSFXType()
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + Vector3.up * 0.05f, Vector3.down, out hit, 0.5f);

            if (hit.collider == null)
                return "Empty";

            if (hit.collider.name.Contains("Terrain"))
                return GetStepSFXTypeFromTerrain(hit);
            else
                return GetStepSFXTypeFromMesh(hit);
        }

        List<string> stepSFXTypes = new List<string>() { "Dirt", "Dirt", "Concrete", "Grass", "Sand", "Concrete"};
                                                                                                       //Rock
        string GetStepSFXTypeFromTerrain(RaycastHit hit)
        {
            Terrain terrain = hit.collider.GetComponent<Terrain>();

            if (terrain == null)
                return "Empty";

            TerrainData data = terrain.terrainData;

            int mapX = Mathf.RoundToInt((transform.position.x - terrain.GetPosition().x) / data.size.x * data.alphamapWidth);
            int mapZ = Mathf.RoundToInt((transform.position.z - terrain.GetPosition().z) / data.size.z * data.alphamapHeight);

            float[,,] splatmap = data.GetAlphamaps(mapX, mapZ, 1, 1);

            float[] weights = new float[splatmap.GetUpperBound(2) + 1];
            int max = -1;
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = splatmap[0, 0, i];

                if (weights[i] > max)
                    max = i;
            }
            return stepSFXTypes[max];
        }

        string GetStepSFXTypeFromMesh(RaycastHit hit)
        {
            string result = "Concrete";
            switch (hit.collider.tag)
            {
                case "Metal":
                    result = "Metal";
                    break;

                case "Concrete":
                    result = "Concrete";
                    break;
            }
            return result;
        }
    }
}