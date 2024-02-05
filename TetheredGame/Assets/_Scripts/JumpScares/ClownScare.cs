using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TG.JumpScares
{
    public class ClownScare : MonoBehaviour, IJumpScare
    {
        void IJumpScare.Scare()
        {
            throw new System.NotImplementedException();
        }
    }
}