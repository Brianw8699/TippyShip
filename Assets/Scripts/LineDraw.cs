using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject linePrefab;
    public GameObject currentline;
    public LineRenderer lineRenderer;
    public Vector3 startmousePos;
    public Vector3 nextmousepos;

    void Start()
    {
        
    }

    
    void Update()
    {
if (Input.GetMouseButtonDown(0))
{
    startmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    startmousePos.z = 8;
    Createline();
}

if(Input.GetMouseButton(0))
{
nextmousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
nextmousepos.z = 8;

if ((Vector2.Distance(startmousePos, nextmousepos)) > .1f)
{

    UpdateLine();
}

}




    }


    void Createline()
    {

        currentline = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentline.GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, startmousePos);
        lineRenderer.SetPosition(1, startmousePos);
        
    }

    void UpdateLine()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, nextmousepos);

    }
}
