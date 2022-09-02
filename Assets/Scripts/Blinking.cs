using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Blinking : MonoBehaviour
{
    Light2D myLight;
    Light2D myLightSonar;
    double timeLastRun;
    bool lightOn = false;
    
    void Start(){

        myLight = GetComponent<Light2D>();
        timeLastRun = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.fixedTime - timeLastRun > 3 && !lightOn){
            myLight.intensity = 0.5f;
            timeLastRun = Time.fixedTime;
            lightOn = true;
        }

        if(Time.fixedTime - timeLastRun > 3 && lightOn)
        {
            myLight.intensity = 0.2f;
            timeLastRun = Time.fixedTime;
            lightOn = false;
        }
        
       
        
    }
}
