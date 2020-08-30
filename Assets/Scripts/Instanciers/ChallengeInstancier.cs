using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeInstancier : InstanceByArea
{
    
    public static ChallengeInstancier metod;
    
    void Awake (){
        if(metod == null)
        {
            metod = this;
            DontDestroyOnLoad(metod);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
