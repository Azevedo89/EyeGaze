using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

public class MoveUiGaze : MonoBehaviour, IGazeFocusable
{

    public RectTransform image;
    public bool Eye;
    public GameObject Canvas; 
    public float time = 0;
    public bool CanMove;

    // Start is called before the first frame update

    void Start()
    {
        RectTransform myRectTransform = GetComponent<RectTransform>();
        Eye = false;
        Debug.Log("isActive " + Canvas.activeSelf);
    }

    // Update is called once per frame

    void Update()
    {
        if (Eye)
        {
            timer();
           // MoveBallWithEyes();    
        } 
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        float time = 0;

        //If this object received focus, fade the object's color to highlight color

        if (hasFocus)
        {
                //Canvas.SetActive(false);
                 Eye = true;
                //MoveBallWithEyes();
                Debug.Log("Entrou aqui");            
        }

        //If this object lost focus, fade the object's color to it's original color

        else
        {
            Eye = false;
        }
    }

    /*public void MoveBallWithEyes()
    {
        image.localPosition += Vector3.right;
    }*/

    public void timer()
    {
        //float time = 0;
        time += Time.deltaTime * 1;
        Debug.Log("Time = " + time);
        if (time >= 5)
        {
            Debug.Log("Já atingiu o tempo necessário");
            CanMove = true;
            Canvas.SetActive(false);
        }
        else
        {
            //time = 0;
            Debug.Log("Saiu aqui");
        }
    } 
}
