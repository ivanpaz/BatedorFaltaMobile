using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{

    [SerializeField]
    private int numTrys;
    public float[] listTrys;
    public int positionTry = 0;
    public int PositionTry { get; }



    public ShootManager(int num)
    {
        numTrys = num;
        //cria array com tamanho do numero de tenttivas
        listTrys = new float[num];
       
    }
    
    
    public bool TryShoot()
    {
        if (positionTry < numTrys)
        {
            positionTry++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddScoreTry(float score)
    {
        
        Debug.Log("Tentativa "+ positionTry + " foi de " + score);
        listTrys[positionTry - 1] += score;
    }

   
    public void AddScoreToHud(HUD_Shoots hud_shoots)
    {
        hud_shoots.SetTryScore(positionTry, listTrys[positionTry - 1]);
    }

    public void ShowAllScores()
    {
        int i = 1;
        foreach (float l in listTrys)
        {
            Debug.Log("Tentativa " + i+ " foi de " + l);
            i++;
        }
    }

    public bool CanTry()
    {
        if (positionTry < numTrys)
        {
           return true;
        }
        else
        {
            return false;
        }
    }

    //Retorna o numero e tentativas restantes
    public int NumTrys()
    {
        return numTrys - positionTry;
    }

    public void Restart()
    {
        positionTry = 0;
        listTrys = new float[numTrys];
    }


   
}
