using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour{
    public ParticleSystem yourParticleSystem;
    Rigidbody2D m_Rigidbody;
    float thrust = 12f;
    public float fuel = 1000f;
    float fuelBurn = 10f;
    public float maxFuel = 2000f;
    public float rotMult = -2f;
    int maxAltScore;
    Vector3 startPosition;
    Vector2 startVelocity;
    public Button leftButton;
    bool isBoostButtonPressed;
    bool isRightButtonPressed;
    bool isLeftButtonPressed;
    public Text fuelAmountDisplay;
    public Text altitude;
    public Text maxAltDisplay;
    public Camera cameraObject;
    public UnityEngine.Rendering.Universal.Light2D boosterGlow;
    public UnityEngine.Rendering.Universal.Light2D refuelLight;
    public UnityEngine.Rendering.Universal.Light2D boostLight;
    public UnityEngine.Rendering.Universal.Light2D rightHeadlight;
    public UnityEngine.Rendering.Universal.Light2D leftHeadlight;
    public float boosterGlowRotation = 180f;
    public GameObject beacon;
    public GameObject beaconJournalPrefab;
    public float timePlaced;
    public GameObject parentTest;
    

    void Start(){
        boosterGlowRotation = 180f;
        boosterGlow.intensity = 0;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        fuel = maxFuel;

        //Assigns values of capsules starting position to variables for resetting position and velocity to 0 when needed
        startPosition = m_Rigidbody.transform.position;
        startVelocity = m_Rigidbody.velocity;
    }

    public void ResetPosition(){
        /*Function for resetting position
        Brings position of rigid body back to the initial position
        Brings velocity back to initial velocty (0)
        Resets rotation to 0 
        Resets fuel to maxfuel
        */
        m_Rigidbody.transform.position = startPosition;
        m_Rigidbody.velocity = startVelocity;
        m_Rigidbody.angularVelocity = 0;
        m_Rigidbody.rotation = 0f;
        fuel = maxFuel;
        
    }

    public void ResetCamera(){
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().Offset.x = 0;
        GameObject.Find("Main Camera").GetComponent<CameraFollow>().Offset.y = 0;
    }

    public void BoostButtonPressed(bool n){
        //Passes a boolean to the variable isBoostButtonPressed from the touch button "Boost"
        //Button is called by the boost button
        isBoostButtonPressed = n;
    }

    public void RightButtonPressed(bool n){
        //Passes a boolean to the variable isBoostButtonPressed from the touch button "Right"
        //Function is called by the right button
        isRightButtonPressed = n;
    }

    public void LeftButtonPressed(bool n){
        //Passes a boolean to the variable isBoostButtonPressed from the touch button "Left"
        //Function is called by the left button 
        isLeftButtonPressed = n;
    }
  
    public void RotateTheShip(int n){
        //Function adds torque from the left and right buttons
        m_Rigidbody.AddTorque(n * rotMult); 
    }
    
    public void AddThrust(){
        //Function adds force up and subtracts fuel each time it is used
        m_Rigidbody.AddForce(transform.up * thrust);
        yourParticleSystem.Play();
        fuel -= fuelBurn;
        boosterGlow.intensity += .05f;
    }    
    void FixedUpdate(){
        fuelAmountDisplay.text = fuel.ToString();
        altitude.text = (Mathf.FloorToInt(m_Rigidbody.transform.position.y)+4).ToString();
        maxAltDisplay.text = maxAltScore.ToString();


        if (maxAltScore < (Mathf.FloorToInt(m_Rigidbody.transform.position.y)+4)){
            maxAltScore = (Mathf.FloorToInt(m_Rigidbody.transform.position.y)+4);
        }

        ///////////////
        //Main Controls
        ///////////////

        if ((Input.GetButton("Jump") || isBoostButtonPressed) && fuel > 0){
            AddThrust();
            boostLight.intensity = 1;
        }
        else{
            yourParticleSystem.Stop();
            boostLight.intensity = 0;
            if (boosterGlow.intensity > 0){
                boosterGlow.intensity -= 0.1f;
            }
        }


        if (fuel == 0 && leftHeadlight.intensity > 0 && rightHeadlight.intensity > 0 ){
            leftHeadlight.intensity -= .01f;
            rightHeadlight.intensity -= .01f;    
        } else if (leftHeadlight.intensity < .7 && rightHeadlight.intensity < .7 && fuel > 100){
            leftHeadlight.intensity += .01f;
            rightHeadlight.intensity += .01f;
        }

        if (Input.GetKey("right") || isRightButtonPressed){
           RotateTheShip(1);
           if(boosterGlowRotation <= 190f){
            boosterGlowRotation+= 1f;
           }

        } else if(boosterGlowRotation>=180){

           boosterGlowRotation-=.1f;
        }

        if (Input.GetKey("left") || isLeftButtonPressed){
           RotateTheShip(-1);
           if(boosterGlowRotation >= 170f){
           boosterGlowRotation-= 1f;
           }
        } else if(boosterGlowRotation<=180){
          boosterGlowRotation+=.1f;
        }

        if (Input.GetKey("down") && (Time.fixedTime - timePlaced > 3)){
            GameObject beacon1 = Instantiate(beacon, m_Rigidbody.transform.position, Quaternion.identity);
            GameObject beaconJournal = Instantiate(beaconJournalPrefab, new Vector2(m_Rigidbody.transform.position.x, m_Rigidbody.transform.position.y), Quaternion.identity);
            beaconJournal.transform.SetParent(parentTest.transform);
            beacon1.GetComponent<Rigidbody2D>().velocity = new Vector2(m_Rigidbody.velocity.x, m_Rigidbody.velocity.y);
            Physics2D.IgnoreCollision(beacon1.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            timePlaced = Time.fixedTime;
        }



   // boosterGlowRotation = 170f;
    boosterGlow.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, boosterGlowRotation);


        if (Input.GetKey(KeyCode.R)){
           ResetPosition();
           ResetCamera();
           boosterGlow.intensity = 0f;
            boosterGlowRotation = 180f;
        }
        ///////////////
        //End Controls
        ///////////////

        //Checks if velocity is between -.01 and .01 and adds fuel (when ship is stationary fuel is added)
        if (m_Rigidbody.velocity.y > -.01 && m_Rigidbody.velocity.y <.01   && fuel < maxFuel){
            fuel+=10;
            refuelLight.intensity = 1;
        } else {
            refuelLight.intensity = 0;
        }
    }
}