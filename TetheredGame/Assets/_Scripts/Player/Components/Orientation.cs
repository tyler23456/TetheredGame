using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    [System.Serializable]
    public class Orientation : IOrientation
    {
        public Transform transform;

        public bool xAxis = true;
        public bool yAxis = true;
        public bool zAxis = true;

        public float interpolation { get; set; } = 0.12f;
        Vector3 eulerAngles = Vector3.zero;

        public void Update()
        {
            InterpolateRotation();
        }

        public void SetAxes(bool xAxis, bool yAxis, bool zAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
            this.zAxis = zAxis;
        }

        public void Set(Vector3 eulerAngles)
        {
            this.eulerAngles = eulerAngles;
        }

        public void Forward(Vector3 forward)
        {

            this.eulerAngles = Quaternion.LookRotation(forward).eulerAngles;
        }

        public void Add(Vector3 eulerAnglesOffset)
        {
            this.eulerAngles += eulerAnglesOffset;
        }

        public void Forward(Vector3 relativeForward, Vector3 localForward)
        {
            this.eulerAngles = Quaternion.LookRotation(relativeForward).eulerAngles + Quaternion.LookRotation(localForward).eulerAngles;
        }

        void InterpolateRotation()
        {
            eulerAngles.x *= Convert.ToInt32(xAxis);
            eulerAngles.y *= Convert.ToInt32(yAxis);
            eulerAngles.z *= Convert.ToInt32(zAxis);

            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(eulerAngles), interpolation * 50f * Time.deltaTime);
        }
    }
}