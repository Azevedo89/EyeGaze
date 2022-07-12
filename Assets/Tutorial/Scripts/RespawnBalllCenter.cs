using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBalllCenter : MonoBehaviour
{

    public GameObject Sphere;

    private void OnTriggerEnter(Collider other)
    {
        Sphere.transform.position = new Vector3(0,0,0);
    }
}
