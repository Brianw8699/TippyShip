using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class BlinkingForBeacon : MonoBehaviour
{
    Light2D myLight;
    Light2D myLightSonar;
    double timeLastRun;
    public float lightOnIntensity;
    public float lightOffIntensity;
    bool lightOn = false;
    
    void Start(){

        myLight = GetComponent<Light2D>();
        timeLastRun = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.fixedTime - timeLastRun > 3 && !lightOn){
            myLight.intensity = lightOnIntensity;
            timeLastRun = Time.fixedTime;
            lightOn = true;
        }

        if(Time.fixedTime - timeLastRun > 3 && lightOn)
        {
            myLight.intensity = lightOffIntensity;
            timeLastRun = Time.fixedTime;
            lightOn = false;
        }
        
       
        
    }
}
