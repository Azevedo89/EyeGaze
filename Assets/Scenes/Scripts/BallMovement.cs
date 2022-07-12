using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour,IMovement
{
    public Rigidbody _rb; 
    private float _speed = 5.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {   
        //float horizontalMovement = Input.GetAxis("Horizontal");
        //float verticalMovement = Input.GetAxis("Vertical");
        
        Vector3 moveBall = new Vector3(HorizontalMovement(),0, VerticalMovement());
        _rb.AddForce(moveBall * _speed);
    }

    public float HorizontalMovement()
    {
        return Input.GetAxis("Horizontal");
    }

    public float VerticalMovement()
    {
        return Input.GetAxis("Vertical");
    }
}
