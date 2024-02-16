using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Equipment
{
    [CreateAssetMenu(fileName = "New Object Effect", menuName = "Object Effect")]
    public class ObjectEffect : ItemBase, IEquipment
    {
        [SerializeField] GameObject prefab;

        public override void Initialize()
        {
            
        }

        public override void Use(GameObject user)
        {
            GameObject obj = GameObject.Instantiate(prefab, user.transform.GetChild(0));
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
        }
    }
}