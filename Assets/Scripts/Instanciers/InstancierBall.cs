using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancierBall : MonoBehaviour
{

    [SerializeField]
    GameObject ball;

    [SerializeField]
    GameController gameController;

    [SerializeField]
    Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        gameController.Ball = Instancier.metod.Instantiate(ball, "Bolas", transform).GetComponent<Ball>();
        gameController.Ball.BallConstructor(initPos);
    }

    
}
