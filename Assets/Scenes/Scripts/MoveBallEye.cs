using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

namespace Tobii.XR.Examples.GettingStarted
{

    public class MoveBallEye : MonoBehaviour, IGazeFocusable
    {
        public Renderer SphereRend;
        public Transform target;
        public float t;
        public float speed; 
        public bool Eye;
        public GameObject respawn;
   
        public void GazeFocusChanged(bool hasFocus)
        {
            //If this object received focus, fade the object's color to highlight color
            if (hasFocus) 
            {
                //Call SetColor using the shader property name "_Color" and setting the color to red
                SphereRend.material.SetColor("_Color", Color.red);
                Eye = true;
                Debug.Log("Entou aqui");
            }
            //If this object lost focus, fade the object's color to it's original color
            else
            {
                SphereRend.material.SetColor("_Color", Color.green);
                Eye = false;
                Debug.Log("Saiu daqui");
            }
        }

        void Awake()
        {
            respawn = GameObject.FindGameObjectWithTag("Sphere");
        }

        // Start is called before the first frame update
        void Start()
        {
            SphereRend = gameObject.GetComponent<Renderer>();
            target = respawn.transform;
            Eye = false;
           // GazeFocusChanged(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(Eye == true)
            {
                MoveBallWithEyes();
            }
        }

        public void MoveBallWithEyes()
        {
            //Lerp
            Vector3 a = transform.position;
            Vector3 b = target.position;
            target.position = Vector3.MoveTowards(b, Vector3.Lerp(a, b, t), speed);
        } 
    }
}