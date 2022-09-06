using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelIndicatorLightController : MonoBehaviour{
    public GameObject TippyShip;
    public UnityEngine.Rendering.Universal.Light2D refuelIndicator0;
    public UnityEngine.Rendering.Universal.Light2D refuelIndicator1;
    public UnityEngine.Rendering.Universal.Light2D refuelIndicator2;
    public UnityEngine.Rendering.Universal.Light2D refuelIndicator3;


    double timeLastRun = 0;
    bool lightOn = false;
    public double blinkInterval;

    bool Blink(){

        if (Time.fixedTime - timeLastRun > blinkInterval && !lightOn){
            refuelIndicator3.intensity = 0.5f;
            timeLastRun = Time.fixedTime;
            lightOn = true;
        }

        if(Time.fixedTime - timeLastRun > blinkInterval && lightOn)
        {
            refuelIndicator3.intensity = 0.2f;
            timeLastRun = Time.fixedTime;
            lightOn = false;
        }
        return lightOn;
    }
    void Update()
    {
        
        if (TippyShip.GetComponent<ShipController>().fuel > 0){
            
                refuelIndicator0.intensity = 3;
                 if (TippyShip.GetComponent<ShipController>().fuel > .33*2000){
                    refuelIndicator1.intensity = 3;
                 }
                 else{
                    refuelIndicator1.intensity = 0;
                 }
                    if (TippyShip.GetComponent<ShipController>().fuel > .66*2000){
                        refuelIndicator2.intensity = 3;
                    }
                    else{
                        refuelIndicator2.intensity = 0;
                    }
                        if (TippyShip.GetComponent<ShipController>().fuel > .99*2000){
                            if (Blink()){
                                refuelIndicator3.intensity = 5;
                            }
                        }
                        else{
                            refuelIndicator3.intensity = 0;
                        }
                        
        }
        else{
            refuelIndicator0.intensity = 0;
            refuelIndicator1.intensity = 0;
            refuelIndicator2.intensity = 0;
            refuelIndicator3.intensity = 0;
        }
        
    }
    
}