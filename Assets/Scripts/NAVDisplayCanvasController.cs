using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NAVDisplayCanvasController : MonoBehaviour
{

    public GameObject tiltmeter;
    public GameObject tiltmeterReference;
    public GameObject tiltmeterFlame;
    public Text maxAltText;
    public Text alt;
    public Text rotationMeter;
    int maxAltScore;
    int angleForText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiltmeterReference.GetComponent<ShipController>().boosterGlow.intensity > 0){
            tiltmeterFlame.SetActive(true);
        }
        else{
            tiltmeterFlame.SetActive(false);
        }

        tiltmeter.transform.eulerAngles = new Vector3(0f, 0f, tiltmeterReference.transform.eulerAngles.z);
        angleForText =  Mathf.RoundToInt(tiltmeter.transform.eulerAngles.z);
        if (angleForText > 180)
        {
            angleForText -= 360;
        }
        angleForText = -angleForText;
        rotationMeter.text = (angleForText.ToString()) + "°";
        
         if (maxAltScore < (Mathf.RoundToInt(tiltmeterReference.transform.position.y)+14)){
            maxAltScore = (Mathf.RoundToInt(tiltmeterReference.transform.position.y)+14);
        }

        maxAltText.text = maxAltScore.ToString();
        alt.text = (Mathf.RoundToInt(tiltmeterReference.transform.position.y) + 14).ToString();




    }
}
