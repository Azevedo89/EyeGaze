using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour, IMove
{
  [SerializeField] 
  private Rigidbody Rigidbody;

  public float Speed;  
  
  void FixedUpdate()
  {
    
    Vector3 movebBall = new Vector3(MoveHor(),0,MoveVer());

    Rigidbody.AddForce(movebBall*Speed);
  }


  public float MoveHor(){
    return  Input.GetAxis("Horizontal");
  }
  
  public float MoveVer(){
       return  Input.GetAxis("Vertical");
  }
}
