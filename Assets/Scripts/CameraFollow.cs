 using UnityEngine;
 public class CameraFollow : MonoBehaviour
 {
     public Transform Player;
     public Vector3 Offset;
     public GameObject tippyShip;
     public Camera CameraForRadar;
     public bool allBeaconsVisible;
 
     void LateUpdate ()
     {
        int numberVisible = 0;
        int numberNotVisible = 0;
         if (Player != null)
             transform.position = Player.position + Offset;

        for (int i = 0; i < tippyShip.GetComponent<ShipController>().beaconCount; i++)
        {
            Debug.Log(i);
           if (GameObject.Find("beaconjournal" + (i+1)).GetComponent<Renderer>().isVisible){
            Debug.Log("IsVisibileFromScript");
            numberVisible++;

           }
           else{
            Debug.Log("IsNotVisibileFromScript");
            allBeaconsVisible = false;
            numberNotVisible ++;
           }

        }

        if (numberNotVisible != 0){
            CameraForRadar.orthographicSize+= .05f;
        }
        if (numberNotVisible == 0 && CameraForRadar.orthographicSize > 35){
            CameraForRadar.orthographicSize-= .05f;
        }
        


     }
 }