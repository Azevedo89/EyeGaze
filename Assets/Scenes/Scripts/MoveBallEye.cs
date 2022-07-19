using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

namespace Tobii.XR.Examples.GettingStarted
{

    public class MoveBallEye : MonoBehaviour, IGazeFocusable
    {
        public Renderer SphereRend;

        public void GazeFocusChanged(bool hasFocus)
        {
            //If this object received focus, fade the object's color to highlight color
            if (hasFocus)
            {
                //Call SetColor using the shader property name "_Color" and setting the color to red
                SphereRend.material.SetColor("_Color", Color.red);
            }
            //If this object lost focus, fade the object's color to it's original color
            else
            {
                SphereRend.material.SetColor("_Color", Color.green);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            SphereRend = gameObject.GetComponent<Renderer>();
            GazeFocusChanged(false);
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void MoveBallWithEyes()
        {

        }
    }
}