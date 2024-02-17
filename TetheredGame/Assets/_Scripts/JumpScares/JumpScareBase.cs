using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareBase : MonoBehaviour
{
    IGlobal global;

    [SerializeField] SphereCollider userCollider;

    protected void Start()
    {
        global = GameObject.Find("/DontDestroyOnLoad").GetComponent<IGlobal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = (other.bounds.center - userCollider.bounds.center);
        bool hasDirectLineOfSight = Physics.Raycast(new Ray(userCollider.bounds.center, direction), 100f);

        if (!hasDirectLineOfSight)
            return;

        Scare();
    }

    public virtual void Scare() { }
}
