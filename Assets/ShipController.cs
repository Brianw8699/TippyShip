using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class ShipController : MonoBehaviour
{
    public ParticleSystem yourParticleSystem;
    Rigidbody2D m_Rigidbody;
    public float m_Thrust = 20f;
    public float fuel = 1000f;
    public float fuelburn = 100;
    public float maxfuel = 6000;
    public float rotmult = 1;
    public int maxaltscore;
    public Vector3 startposition;
    public Vector2 startvelocity;
    public Button leftButton;
    public string m_memberID = "brianwilliam";
    public bool isBoostButtonPressed;
    public bool isRightButtonPressed;
    public bool isLeftButtonPressed;
    public Text txt;
    public Text altitude;
    public Text maxaltdisplay;
    public Text usernamefield;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        fuel = maxfuel;

        //Assigns values of capsules starting position to variables for resetting position and velocity to 0 when needed
        startposition = m_Rigidbody.transform.position;
        startvelocity = m_Rigidbody.velocity;


        //Assigns MemberID from UI input field for leaderboard 
        m_memberID = usernamefield.text.ToString();
        //Lootlocker initilization for leaderboard
        LootLockerSDKManager.StartGuestSession("Brian", (response) =>
        {
        if (response.success)
        {

            Debug.Log("Lootlocker Init Success");
        }
        else
        {
            Debug.Log("Lootlocker init fail");
        }
        
        });
    }


/*Function for resetting position

Brings position of rigid body back to the initial position
Brings velocity back to initial velocty (0)
Resets rotation to 0 
Resets fuel to maxfuel


*/
public void resetPosition()
{
m_memberID = usernamefield.text.ToString();
m_Rigidbody.transform.position = startposition;
m_Rigidbody.velocity = startvelocity;
m_Rigidbody.angularVelocity = 0;
m_Rigidbody.rotation = 0f;
fuel = maxfuel;
}


//Passes a boolean to the variable isBoostButtonPressed from the touch button "Boost"
//Button is called by the boost button
public void BoostButtonPressed(bool n)
{
isBoostButtonPressed = n;
}

//Passes a boolean to the variable isBoostButtonPressed from the touch button "Right"
//Function is called by the right button
public void RightButtonPressed(bool n)
{
isRightButtonPressed = n;
}


//Passes a boolean to the variable isBoostButtonPressed from the touch button "Left"
//Function is called by the left button 
public void LeftButtonPressed(bool n)
{
isLeftButtonPressed = n;
}



//Function adds torque from the left and right buttons
public void rotatetheship(int n)
{
m_Rigidbody.AddTorque(n * rotmult); 
}
    
//Function adds force up and subtracts fuel each time it is used
public void addThrust()
{
     m_Rigidbody.AddForce(transform.up * m_Thrust);
            yourParticleSystem.Play();
            fuel -= fuelburn;
}

///////////////////////
/*
Main game loop
*/
//////////////////////
    
    void FixedUpdate()
    {

        txt.text = fuel.ToString();
        altitude.text = (Mathf.FloorToInt(m_Rigidbody.transform.position.y)+4).ToString();
        maxaltdisplay.text = maxaltscore.ToString();


        if (maxaltscore < (Mathf.FloorToInt(m_Rigidbody.transform.position.y)+4))
        {
            maxaltscore = (Mathf.FloorToInt(m_Rigidbody.transform.position.y)+4);
        }

        ///////////////
        //Main Controls
        ///////////////

        if ((Input.GetButton("Jump") || isBoostButtonPressed) && fuel > 0)
        {
        addThrust();
        }
        else
        {
        yourParticleSystem.Stop();
        }


        if (Input.GetKey("right") || isRightButtonPressed)
        {
           rotatetheship(1);
        }

        if (Input.GetKey("left") || isLeftButtonPressed)
        {
           rotatetheship(-1);
        }


            //Resets position and also submits maximum altitude score to the leaderboard
       if (Input.GetKey(KeyCode.R))
       {
           resetPosition();

   LootLockerSDKManager.SubmitScore(m_memberID, maxaltscore, 5378, (response) =>
                    {   
                        if (response.statusCode == 200) {
                            Debug.Log("Successful");
                        } else {
                            Debug.Log("failed: " + response.Error);
                        }
                    });
       }


        ///////////////
        //End Controls
        ///////////////



    //Checks if velocity is between -.01 and .01 and adds fuel (when ship is stationary fuel is added)
    if (m_Rigidbody.velocity.y > -.01 && m_Rigidbody.velocity.y <.01   && fuel < maxfuel)
    {
    fuel+=10;
    }





    }



}