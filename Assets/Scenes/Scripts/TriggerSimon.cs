using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSimon : MonoBehaviour
{
    private string _triggerName;
    private Vector3 _gameObjectPosition;
    public GameManager GameManager;

    void Start(){
        _gameObjectPosition = gameObject.transform.localPosition;
        GameManager =  GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Debug.Log(SimonPosition());
    }

    private void OnTriggerEnter(Collider other)
    {
        _triggerName = gameObject.tag;
        //Debug.Log(_triggerName);
        GameManager.AddNameSelectedByUser(getName());
        GameManager.RemoveSimonFromList(gameObject.GetComponent<TriggerSimon>());
        Destroy(gameObject);
    }

    public string getName(){
        return _triggerName;
    }

    public Vector3 SimonPosition(){
        return _gameObjectPosition;
    }
}