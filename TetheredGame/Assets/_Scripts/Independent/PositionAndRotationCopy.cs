using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.Independent
{
    public class PositionAndRotationCopy : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] float lerpSpeed = 0.1f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 50f * lerpSpeed);
            transform.forward = Vector3.Lerp(transform.forward, target.forward, Time.deltaTime * 50f * lerpSpeed);
        }
    }
}