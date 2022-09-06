using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDisplayController : MonoBehaviour
{
    public GameObject tiltometer;
    public GameObject player;
    public Shader shader;


    void Start(){
        
        DrawLine(Vector3.zero, new Vector3(5f, 5f, 0f), Color.blue);


    }
    void Update()
    {

        tiltometer.transform.eulerAngles = player.transform.eulerAngles;
        
    }
 void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 5f)
         {
             GameObject myLine = new GameObject();
             myLine.transform.position = start;
             myLine.AddComponent<LineRenderer>();
             LineRenderer lr = myLine.GetComponent<LineRenderer>();
             lr.material = new Material(shader);
             lr.startColor = Color.blue;
             lr.startWidth = 5f;
             lr. endWidth = 5f;
             lr.SetPosition(0, start);
             lr.SetPosition(1, end);
             GameObject.Destroy(myLine, duration);
         }


}
