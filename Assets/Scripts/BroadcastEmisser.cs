using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastEmisser : MonoBehaviour
{
    private BroadcastListener listener;
    public BroadcastListener Listener
    {
        get { return listener; }
    }

    void Start()
    {
        //StartCoroutine(TestBroadcast(2f));
        listener = BroadcastListener.Instance;

    }

    public void SenMenssage(string command, float value) {
        
    }

    

    private IEnumerator TestBroadcast(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //BroadcastMessage("TestListener", 5f);
            BroadcastListener.Instance.TestListener(162);
        }
    }



   
}
