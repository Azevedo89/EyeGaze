using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour, IMovement
{
   private float _smooth = 5.0f;
   private float _tiltAngle = 20.0f;

    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the plane by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(VerticalMovement(), 0, -HorizontalMovement());

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * _smooth);  
    }
    
    public float HorizontalMovement()
    {
        return Input.GetAxis("Horizontal")* _tiltAngle;
    }

    public float VerticalMovement()
    {
        return Input.GetAxis("Vertical")* _tiltAngle;
    }
}
