using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Aim
    {
        [SerializeField] Transform target;
        [SerializeField] Camera mainCamera;

        public void Update()
        {
            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = mainCamera.ScreenPointToRay(screenCenterPoint);

            bool hasHit = Physics.Raycast(ray, out RaycastHit hit, 1000f);

            if (hasHit)
                target.position = Vector3.Lerp(target.position, hit.point, 0.4f);
            else
                target.position = Vector3.Lerp(target.position, ray.origin + ray.direction * 5f, 0.4f);

        }


    }
}