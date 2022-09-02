using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBarController : MonoBehaviour{
    public RectTransform fuelBar;
    public GameObject ship;
    float currentY;

    // Update is called once per frame
    void Update(){
        float fuel = ship.GetComponent<ShipController>().fuel;
        fuelBar.sizeDelta = new Vector2(fuel/5.1f, 20f);
        //fuelBar.localPosition.x -= fuel/10;
        fuelBar.localPosition = new Vector2(0 - (400-fuel/5.1f)/2, 0f);
        
       // Debug.Log(0-(200-fuel/20));
        //fuelBar.anchoredPosition.x
    }
}
