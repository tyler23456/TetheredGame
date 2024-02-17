using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareBase : MonoBehaviour
{
    IGlobal global;

    protected void Start()
    {
        global = GameObject.Find("/DontDestroyOnLoad").GetComponent<IGlobal>();
    }

    

}
