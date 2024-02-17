using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Equipment
{
    [CreateAssetMenu(fileName = "New Object Spawner", menuName = "Object Spawner")]
    public class ObjectSpawner : ItemBase, IEquipment
    {
        static bool isInitialized = false;
        static Collider[] colliders;
        static Transform parent;
        static GameObject obj = null;
        static Collider collider = null;
        static List<Collider> spawned;

        [SerializeField] GameObject prefab;
        [SerializeField] float count;

        public new void Awake()
        {
            base.Awake();
            colliders = GameObject.Find("/Office/Floors").GetComponentsInChildren<Collider>();
            parent = GameObject.Find("/Office/Spawned").transform;
        }

        public override void Use(GameObject user)
        {
            ICharacter character = user.GetComponent<ICharacter>();
            character.getStats.OffsetAttribute("Thrill", 20);

            //this method does not check for collision
            for (int i = 0; i < count; i++)
            {
                collider = colliders[Random.Range(0, colliders.Length)];
                Vector3 position = collider.bounds.center;
                float eulerAngleY = Random.Range(0f, 359.9f);
                obj = GameObject.Instantiate(prefab, parent);
                obj.transform.localPosition = position;
                obj.transform.localRotation = Quaternion.Euler(0f, eulerAngleY, 0f);
                //obj.transform.localScale = Vector3.one;
            }
        }
    }
}