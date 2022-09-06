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
    public Camera cameraObject;
    public UnityEngine.Rendering.Universal.Light2D boosterGlow;
    public UnityEngine.Rendering.Universal.Light2D shipGlow;
    public UnityEngine.Rendering.Universal.Light2D rightHeadlight;
    public UnityEngine.Rendering.Universal.Light2D leftHeadlight;
    public float boosterGlowRotation = 180f;
    public GameObject beacon;
    public GameObject beaconJournalPrefab;
    public float timePlaced;
    public GameObject parentTest;
    int i = 0;
    public int beaconCount = 0;
    public GameObject mainCamera;
    public GameObject navigationDisplayCamera;
    public GameObject uiCanvas;
    public GameObject navigationDisplayCanvas;
    

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
        mainCamera.GetComponent<CameraController>().Offset.x = 0;
        mainCamera.GetComponent<CameraController>().Offset.y = 0;
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
        if (boosterGlow.intensity < 9){
        boosterGlow.intensity += .05f;
        }
    }    
    void FixedUpdate(){
        fuelAmountDisplay.text = fuel.ToString();

        ///////////////
        //Main Controls
        ///////////////

        if ((Input.GetButton("Jump") || isBoostButtonPressed || Input.GetKey(KeyCode.W)) && fuel > 0){
            AddThrust();
        }
        else{
            yourParticleSystem.Stop();
            if (boosterGlow.intensity > 0){
                boosterGlow.intensity -= 0.1f;
            }
        }


        if (fuel == 0 && leftHeadlight.intensity > 0 && rightHeadlight.intensity > 0 ){
            leftHeadlight.intensity -= .01f;
            rightHeadlight.intensity -= .01f;
            shipGlow.intensity -= .01f;    
        } else if (leftHeadlight.intensity < .7 && rightHeadlight.intensity < .7 && fuel > 100){
            leftHeadlight.intensity += .01f;
            rightHeadlight.intensity += .01f;
            shipGlow.intensity += .01f;    
        }

        if (isRightButtonPressed || Input.GetKey(KeyCode.D)){
           RotateTheShip(1);
           if(boosterGlowRotation <= 190f){
            boosterGlowRotation+= 1f;
           }

        } else if(boosterGlowRotation>=180){

           boosterGlowRotation-=.1f;
        }

        if (isLeftButtonPressed || Input.GetKey(KeyCode.A)){
           RotateTheShip(-1);
           if(boosterGlowRotation >= 170f){
           boosterGlowRotation-= 1f;
           }
        } else if(boosterGlowRotation<=180){
          boosterGlowRotation+=.1f;
        }

        if (Input.GetKey("down") && (Time.fixedTime - timePlaced > 3)){
            i++;
            GameObject beacon1 = Instantiate(beacon, m_Rigidbody.transform.TransformPoint(new Vector2 (0f, -1.2f)), transform.rotation);
            GameObject beaconJournal = Instantiate(beaconJournalPrefab, new Vector2(m_Rigidbody.transform.position.x, m_Rigidbody.transform.position.y), Quaternion.identity);
            beacon1.name = "brian" + i;
            beaconJournal.name = "beaconjournal" + i;
            beaconJournal.transform.SetParent(parentTest.transform);
            beacon1.GetComponent<Rigidbody2D>().velocity = m_Rigidbody.GetPointVelocity(transform.TransformPoint(new Vector2 (0f, -3f)));
            Physics2D.IgnoreCollision(beacon1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            beaconCount++;
            timePlaced = Time.fixedTime;
        }

 
        if(Input.GetKey(KeyCode.F) || Input.GetKey("left")){
           navigationDisplayCanvas.SetActive(true);
           navigationDisplayCamera.SetActive(true);
           mainCamera.SetActive(false);
           uiCanvas.SetActive(false);
        }
        else{
           mainCamera.SetActive(true);
           uiCanvas.SetActive(true);
           navigationDisplayCamera.SetActive(false);
            navigationDisplayCanvas.SetActive(false);
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
        } 
    
   
    }


 
}