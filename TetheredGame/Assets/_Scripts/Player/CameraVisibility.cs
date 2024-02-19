using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.UserPlayer
{
    public class CameraVisibility : MonoBehaviour
    {
        public bool isVisible { get; private set; } = false;

        protected void OnBecameVisible()
        {
            isVisible = true;
        }

        protected void OnBecameInvisible()
        {
            isVisible = false;
        }
    }
}