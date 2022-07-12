using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRot : MonoBehaviour, IMove
{
    
float smooth = 5.0f;
    float tiltAngle = 20.0f;

    void Update()
    {

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(MoveVer() , 0, -MoveHor());

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
    }

    public float MoveHor(){
    return  Input.GetAxis("Horizontal") * tiltAngle;
  }
  
  public float MoveVer(){
       return  Input.GetAxis("Vertical") * tiltAngle;
  }
}
