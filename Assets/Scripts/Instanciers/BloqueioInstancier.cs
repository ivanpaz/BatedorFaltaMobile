using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueioInstancier : InstanceByArea
{
    public static BloqueioInstancier metod;
    bool activeStatus = true;
    List<BloqueioInstanceController> listBlocks = new List<BloqueioInstanceController>();
    
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

    public void DisableBlocks (){
        Disable(!activeStatus);
    }

    void Disable (bool active){
        if(ItenInstances.Count > 0){
            foreach(BloqueioInstanceController blocks in listBlocks){
                blocks.DesativateActivate(active);
            }
            activeStatus = !activeStatus;
        }
    }

    internal override void AddInstances(GameObject gameObject){
        base.AddInstances(gameObject);
        listBlocks.Add(gameObject.GetComponent<BloqueioInstanceController>());
    }
}
