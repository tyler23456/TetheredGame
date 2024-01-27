using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Orientation : IOrientation
    {
        public void Add(Vector3 eulerAnglesOffset)
        {
            throw new System.NotImplementedException();
        }

        public void Forward(Vector3 forward)
        {
            throw new System.NotImplementedException();
        }

        public void Forward(Vector3 relativeForward, Vector3 localForward)
        {
            throw new System.NotImplementedException();
        }

        public void SetAxes(bool xAxis, bool yAxis, bool zAxis)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {

        }
    }
}