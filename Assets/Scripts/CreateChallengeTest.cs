using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateChallengeTest : MonoBehaviour
{
    void Start (){
        CreateChallenge();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ChallengeInstancier.metod.Create();
            BloqueioInstancier.metod.Create();
        }
    }

    public void CreateChallenge () {
        ChallengeInstancier.metod.Create();
        BloqueioInstancier.metod.Create();
    }
}
