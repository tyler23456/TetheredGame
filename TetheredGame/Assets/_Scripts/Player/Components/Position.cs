using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TG.Player
{
    [System.Serializable]
    public class Position
    {
        [HideInInspector] public Action<Vector3> onMove { get; set; } = (changeInPosition) => { };

        Vector3 offset;

        public void Add(Vector3 offset)
        {
            this.offset += offset;
        }

        public void Update()
        {
            onMove(offset * Time.deltaTime);
            offset = Vector3.zero;
        }
    }
}