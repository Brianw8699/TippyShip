using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
   public Camera cameraObject;
   public Rigidbody2D m_Rigidbody;
   public Transform Player;
    public Vector3 Offset;

    void LateUpdate(){


    if (Player != null)
            transform.position = Player.position + Offset;
    

    if (Input.GetKey("up")){
            if(cameraObject.orthographicSize < 30){
                cameraObject.orthographicSize ++;
            }
        } else {
            //Velocity Camera Control Start
            if (Mathf.Abs(m_Rigidbody.velocity.x) > 5){
                if (Mathf.Abs(m_Rigidbody.velocity.x)+10 > cameraObject.orthographicSize){
                    cameraObject.orthographicSize+= (Mathf.Abs(m_Rigidbody.velocity.x)+10 - cameraObject.orthographicSize) / 300;
                }
            }
            //Subtracts if velocity x and velocity y are less than the camera size
            else if ((Mathf.Abs(m_Rigidbody.velocity.x)+10 < cameraObject.orthographicSize) && (Mathf.Abs(m_Rigidbody.velocity.y)+10 < cameraObject.orthographicSize)) {
                cameraObject.orthographicSize-=  Mathf.Abs(((Mathf.Abs(m_Rigidbody.velocity.x)+10) - cameraObject.orthographicSize)) / 100;
            }
            if  (Mathf.Abs(m_Rigidbody.velocity.y) > 5){
                if (Mathf.Abs(m_Rigidbody.velocity.y)+10 > cameraObject.orthographicSize){
                    cameraObject.orthographicSize+= (Mathf.Abs(m_Rigidbody.velocity.y)+10 - cameraObject.orthographicSize) / 300;
                }

            }
            //Subtracts if velocity x and velocity y are less than the camera size
            else if ((Mathf.Abs(m_Rigidbody.velocity.y)+10 < cameraObject.orthographicSize) && (Mathf.Abs(m_Rigidbody.velocity.x)+10 < cameraObject.orthographicSize)) {
                cameraObject.orthographicSize-=  Mathf.Abs(((Mathf.Abs(m_Rigidbody.velocity.y)+10) - cameraObject.orthographicSize)) / 100;
            }
            //END VELOCITY CAMERA ZOOM



            //START VELOCITY CAMERA PAN 
            //Moves Camera right if velocity is greater than 3 
            if (m_Rigidbody.velocity.x > 3 && (Offset.x < 7)){
                //Debug.Log(CameraObject.transform.position.x);
                Offset.x += .01f;
            } else if (Offset.x > 0f) {
                Offset.x -= .01f;
               // Debug.Log("Subbing");
            }

            //Moves camera left if velocity is less than -3 
            if (m_Rigidbody.velocity.x < -3 && (Offset.x > -7)){
                //Debug.Log(CameraObject.transform.position.x);
                Offset.x -= .01f;
            } else if (Offset.x < 0f) {
                Offset.x += .01f;
               // Debug.Log("Adding");
            }  

            if (m_Rigidbody.velocity.y > 3 && (Offset.y < 7)){
                //Debug.Log(CameraObject.transform.position.x);
                Offset.y += .01f;
            } else if (Offset.y > 0f) {
                Offset.y -= .01f;
           // Debug.Log("Adding");
            }

            if (m_Rigidbody.velocity.y < -3 && (Offset.y > -7)){
                //Debug.Log(CameraObject.transform.position.x);
                Offset.y -= .01f;
            } else if (Offset.y < 0f) {
                Offset.y += .01f;
              //  Debug.Log("Adding");
            }

            //END VELOCITY CAMERA PAN 
        }    
    }
}
