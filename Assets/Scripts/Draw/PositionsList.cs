using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PositionsList : MonoBehaviour
{

    private List<Vector3> listOfPositions = new List<Vector3>();
    public List<Vector3> ListOfPositions
    {
        get { return listOfPositions; }
        set { listOfPositions = value; }
    }

    Vector3 initPoint = new Vector3 (0,0,0);
    public Vector3 InitPoint
    {
        get { return initPoint; }
        set { initPoint = value; }
    }


    Vector3 finalPoint = new Vector3(0, 0, 0);
    public Vector3 FinalPoint
    {
        get { return finalPoint; }
        set { finalPoint = value; }
    }

    float maxHorizontalPoint = 0.0f;
    public float MaxHorizontalPoint
    {
        get { return maxHorizontalPoint; }
        set { maxHorizontalPoint = value; }
    }


    private float maxVerticalPoint = 0.0f;    
    public float MaxVerticalPoint
    {
        get { return maxVerticalPoint; }
        set { maxVerticalPoint = value; }
    }

    private float lenghtLine = 0.0f;
    public float LenghtLine {
        get { return lenghtLine; }
        set { lenghtLine = value; }
    }

    private float widhtLine = 0.0f;
    public float WidhtLine
    {
        get { return widhtLine; }
        set { widhtLine = value; }
    }

    private float verticalMedium = 0.0f;
    public float VerticalMedium
    {
        get { return verticalMedium; }
        set { verticalMedium = value; }
    }







    public void AddToTheList(Vector3 v)
    {
        listOfPositions.Add(v);
    }

    public void DebugPositionsList()
    {
        foreach (Vector3 v in listOfPositions) {
            Debug.Log(v);
        }
    }

    public void DebugDrawLine()
    {
        for (int i = 1; i < listOfPositions.Count; i++)
        {
            Debug.DrawLine(listOfPositions[i - 1], listOfPositions[i], Color.red, 5.0f);
        }
    }

    public void DebugPositionsListCount()
    {
        Debug.Log(listOfPositions.Count);

    }


    void DefineParameters()
    {
        //Debug.Log("listOfPositions.Count:  " + listOfPositions.Count);
        
        if (listOfPositions.Count >1)
        {
            InitPoint = listOfPositions[1];
            FinalPoint = listOfPositions[listOfPositions.Count-1];          
            


            //O primeiro ponto sai com problemas
            for (int i = 1; i < listOfPositions.Count; i++)
            {

                //verificar qual o limite horizontal (X)
                
                if((Mathf.Abs(listOfPositions[i].x - InitPoint.x) > Mathf.Abs(WidhtLine)) && i< listOfPositions.Count/2)
                {
                    WidhtLine = listOfPositions[i].x - InitPoint.x;
                    //Debug.Log(WidhtLine);
                    //MaxHorizontalPoint = Mathf.Abs(listOfPositions[i].x);
                }

                //verificar qual o limite vertical
                if (listOfPositions[i].y > MaxVerticalPoint) 
                {
                    MaxVerticalPoint = listOfPositions[i].y ;
                    
                    
                }

                //Somar os pontos x
                VerticalMedium += listOfPositions[i].x - initPoint.x;
            }
            VerticalMedium = VerticalMedium / listOfPositions.Count - 1;


            //Debug.Log("FinalPoint.x  "+ FinalPoint.x);
            //Debug.Log();

            //Debug.Log("WidhtLine: "+ WidhtLine + "       Distance: " + (FinalPoint.x - InitPoint.x));
            //WidhtLine = WidhtLine -  (FinalPoint.x - InitPoint.x);
            VerticalMedium = WidhtLine - (FinalPoint.x-InitPoint.x);
            //WidhtLine -= InitPoint.x;
            


            //veriricar comprimento maximo da linha
            if (MaxVerticalPoint > initPoint.y)
            {
               
                LenghtLine = Mathf.Abs(MaxVerticalPoint - initPoint.y);
                
                //Debug.Log("LenghtLine - " + LenghtLine);
            }
            //Debug.Log("WidhtLine - " + WidhtLine);

            //Determina a largura máxima da curva
            //WidhtLine = MaxHorizontalPoint - initPoint.x;


        }

       


        GameObject.Find("GameController").GetComponent<GameController>().PrepareShoot(this);


    }

    public void PrepareShoot()
    {
        DefineParameters();
    }
}
