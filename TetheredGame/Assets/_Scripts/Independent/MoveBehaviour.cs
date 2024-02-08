using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Independent
{
    public class MoveBehaviour : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            GetComponent<CharacterController>().Move(Vector3.forward * 5f * Time.deltaTime);
        }
    }
}