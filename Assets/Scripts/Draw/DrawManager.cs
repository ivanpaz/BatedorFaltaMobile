using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    public GameObject drawPrefab;

    GameObject theTrail;
    Plane planeObject;
    Vector3 startPos;

    bool canDraw = true;
    bool canTimer = true;

    
    float currCountdownValue;
    
    PositionsList positionsList = new PositionsList();

    // Start is called before the first frame update
    void Start()
    {
        planeObject = new Plane(Camera.main.transform.forward * -1, this.transform.position);

        //planeObject = new Plane(Camera.main.transform.forward * -1, Camera.main.transform.forward);



    }

    void Update()
    {

        //Debug.Log(Input.touchCount);

        DrawPlane(this.transform.position, Camera.main.transform.forward * -1);        

        if (canDraw)
        {

            if ((Input.touchCount> 0 || Input.GetMouseButtonDown(0)) && canTimer) 
            //if ((Input.touchCount > 0 ) && canTimer)
            {
                //Timer para tempo do desenho
                canTimer = false;
                StartCoroutine(TimerTouch());
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
            {
               


                theTrail = (GameObject)Instantiate(drawPrefab, Camera.main.transform.forward * -1, Quaternion.identity);
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                
                float _distance;
               
                if (planeObject.Raycast(mouseRay, out _distance))
                {
                    
                    startPos = mouseRay.GetPoint(_distance);
                }
               
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
            //else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved )
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float _distance;

                

               if (planeObject.Raycast(mouseRay, out _distance))
                {
                                       
                    theTrail.transform.position = mouseRay.GetPoint(_distance);
                }
               
            }

            
            
        }
        

       //GetNumPos(theTrail.GetComponent<TrailRenderer>());

        //Testes para pegar valores das  posições
        if (Input.GetKeyDown("space"))
        {
            //positionsList.DebugPositionsList();
            //positionsList.DebugPositionsListCount();
            positionsList.DebugDrawLine();
            /*
            Debug.Log("Heigh da camera - " + Camera.main.pixelHeight);
            Debug.Log("Lenght da camera - " + Camera.main.pixelWidth);
            Debug.Log("Rect da camera - " + Camera.main.pixelRect);
            */

            //Debug.Log("InitPOitn  " + positionsList.InitPoint);

           
            //Debug.Log("Largura - " + positionsList.WidhtLine / width);
            //Debug.Log("Altura - " + positionsList.LenghtLine / height);



            //Debug.Log("Horizontal " + positionsList.MaxHorizontalPoint);
            //Debug.Log("Vertical " + positionsList.MaxVerticalPoint);
            //Debug.Log(positionsList.InitPoint);
            //Debug.Log(positionsList.FinalPoint);
            //Debug.Log("Height " + height );
            //Debug.Log("Widht " + width);


        }


    }

    public void GetNumPos(TrailRenderer t)
    {
        Vector3[] positions = new Vector3[1000];
        int n = t.GetComponent<TrailRenderer>().GetPositions(positions);

    }





   
    public IEnumerator TimerTouch(float countdownValue = 2)
    {
        currCountdownValue = countdownValue;
        //Debug.Log("Countdown: " + currCountdownValue);
        while (currCountdownValue > 0)
        {
            
            yield return new WaitForSeconds(1);
            currCountdownValue -= 1;
        }
        
        if (currCountdownValue <= 0)
        {
            EndDraw();           
        }
    }

    void EndDraw()
    {
        canDraw = false;

        TrailRenderer trail = theTrail.GetComponent<TrailRenderer>();
        
        for (int i = 0; i< trail.positionCount; i++ )
        {
            //Debug.Log(trail.GetPosition(i));
            
            positionsList.AddToTheList(trail.GetPosition(i));


        }
        if (positionsList.ListOfPositions.Count>1)
        {
            positionsList.PrepareShoot();
        }
        else
        {
            AllowDraw();
        }
        
    }

    public void AllowDraw()
    {
        
        canDraw = true;
        canTimer = true;
        positionsList = new PositionsList();
    }

    public void NoDraw()
    {
        
        canDraw = false;
        canTimer = false;
    }

    void DrawPlane(Vector3 position, Vector3 normal)
    {

        Vector3 v3;

        if (normal.normalized != Vector3.forward)
            v3 = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude; ;

        var corner0 = position + v3;
        var corner2 = position - v3;
        var q = Quaternion.AngleAxis(90, normal);
        v3 = q * v3;
        var corner1 = position + v3;
        var corner3 = position - v3;

        Debug.DrawLine(corner0, corner2, Color.green);
        Debug.DrawLine(corner1, corner3, Color.green);
        Debug.DrawLine(corner0, corner1, Color.green);
        Debug.DrawLine(corner1, corner2, Color.green);
        Debug.DrawLine(corner2, corner3, Color.green);
        Debug.DrawLine(corner3, corner0, Color.green);
        Debug.DrawRay(position, normal, Color.red);
    }




}
