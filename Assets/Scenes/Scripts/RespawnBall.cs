using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(0,0,0);
    }
}
