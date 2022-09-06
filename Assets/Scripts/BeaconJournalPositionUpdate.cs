using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconJournalPositionUpdate : MonoBehaviour
{ 
    public GameObject Player;
    public int oy;

    void Start(){
        Debug.Log("Hello");
       oy =  GameObject.Find("Tippy Ship").GetComponent<ShipController>().beaconCount;
    }
    
    void Update()
    {

        updatePosition();
    
    }   

    void updatePosition()
    {
  transform.position = new Vector2 (GameObject.Find("brian"+oy).transform.position.x, GameObject.Find("brian"+oy).transform.position.y - 1219);
    }

}
