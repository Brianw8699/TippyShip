using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NAVDisplayCanvasController : MonoBehaviour
{

    public GameObject tiltmeter;
    public GameObject tiltmeterReference;
    public GameObject tiltmeterFlame;
    public GameObject tippyShip;
    public GameObject closest;
    public GameObject closestBeacon;
    public Vector3 position;
    public Vector3 mousePosition;
    public Camera radarCamera;
    public Text maxAltText;
    public Text alt;
    public Text rotationMeter;
    public float lowestDistance = 10;
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
        
        if (maxAltScore < (Mathf.RoundToInt(tiltmeterReference.transform.position.y + 208))){
            maxAltScore = (Mathf.RoundToInt(tiltmeterReference.transform.position.y + 208));
        }

        maxAltText.text = maxAltScore.ToString();
        alt.text = (Mathf.RoundToInt(tiltmeterReference.transform.position.y + 208)).ToString();
        mousePosition  = new Vector3 (radarCamera.ScreenToWorldPoint(Input.mousePosition).x - 21f, radarCamera.ScreenToWorldPoint(Input.mousePosition).y + 10f, radarCamera.ScreenToWorldPoint(Input.mousePosition).z);
        for (int i = 0; i < tippyShip.GetComponent<ShipController>().beaconCount; i++){
            if (GameObject.Find("beaconjournal" + (i+1))){

                if (Vector3.Distance(GameObject.Find("beaconjournal" + (i+1)).transform.position, mousePosition) < lowestDistance){
                    lowestDistance = Vector3.Distance(GameObject.Find("beaconjournal" + (i+1)).transform.position, mousePosition);
                    closest =  GameObject.Find("beaconjournal" + (i+1));
                    closestBeacon = GameObject.Find("brian" + (i+1));
                }
            } else { 
                Debug.Log("No Game Object Reference - Nav Display Canvas Controller");
            }
         
        }
            lowestDistance = 10;


        if (Input.GetMouseButton(0)){
            closest.SetActive(false);
            closestBeacon.SetActive(false);
        }


    }
}
