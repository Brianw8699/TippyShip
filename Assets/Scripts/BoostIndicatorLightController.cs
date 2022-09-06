using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostIndicatorLightController : MonoBehaviour{
    public GameObject boosterLight;
    public UnityEngine.Rendering.Universal.Light2D boostIndicator0;
    public UnityEngine.Rendering.Universal.Light2D boostIndicator1;
    public UnityEngine.Rendering.Universal.Light2D boostIndicator2;
    public UnityEngine.Rendering.Universal.Light2D boostIndicator3;
    public UnityEngine.Rendering.Universal.Light2D boostIndicator4;

    // Update is called once per frame
    void Update()
    {
        if (boosterLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity > 0){
                boostIndicator0.intensity = 3;
                 if (boosterLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity > 2){
                    boostIndicator1.intensity = 3;
                 }
                 else{
                    boostIndicator1.intensity = 0;
                 }
                    if (boosterLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity > 4){
                        boostIndicator2.intensity = 3;
                    }
                    else{
                        boostIndicator2.intensity = 0;
                    }
                        if (boosterLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity > 6){
                            boostIndicator3.intensity = 3;
                        }
                        else{
                            boostIndicator3.intensity = 0;
                        }
                            if (boosterLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity > 8){
                                boostIndicator4.intensity = 3;
                            }
                            else{
                                boostIndicator4.intensity = 0;
                            }
        }
        else{
            boostIndicator0.intensity = 0;
            boostIndicator1.intensity = 0;
            boostIndicator2.intensity = 0;
            boostIndicator3.intensity = 0;
            boostIndicator4.intensity = 0;
        }
    }
}
