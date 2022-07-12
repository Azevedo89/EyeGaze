using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonObject : MonoBehaviour
{
    public SimonManager SimonManager;
    private string _tagName;


    public void Start(){
        SimonManager = GameObject.FindWithTag("GameManager").GetComponent<SimonManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        _tagName = gameObject.tag;

        SimonManager.AddToList(_tagName);

        SimonManager.RemoveFromList(gameObject);
        Destroy(gameObject);
    }
}
