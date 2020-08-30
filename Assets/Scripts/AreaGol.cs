using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGol : MonoBehaviour
{

    BoxCollider box;
    [SerializeField] LayerMask mask;
    [SerializeField] AudioClip audio;

    //Score
    [SerializeField] float points = 25f;
    void Start()
    {
        box = GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Ball")
        {
            BroadcastListener.Instance.Linten("addScore", points);
        }
    }


}
