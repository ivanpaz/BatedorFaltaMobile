using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
    public Rigidbody body;
    private bool shoot = false;
    private bool efeito = false;
    //private float resistenciaGrama = 0.2f;
    private float powerFoward; //Forca para frente
    public float powerUp; //Forca para cima
    public float powerRight; // Forca de abertura da acurva
    public float powerCurva; //Intensidade da Curva (testar melhor)

    private float curva = 0;

    private Slider slidePowerFoward;
    private Slider slidePowerUp;
    private Slider slidePowerRight;
    private Slider slidePowerCurva;

    private Vector3 initPos;

    public bool touchShoot = true;

    




    // Start is called before the first frame update
    void Start()
    {
        slidePowerFoward = GameObject.Find("ForcaChute").GetComponentInChildren<Slider>();
        slidePowerUp = GameObject.Find("AlturaChute").GetComponentInChildren<Slider>();
        slidePowerRight = GameObject.Find("CurvaChute").GetComponentInChildren<Slider>();
        slidePowerCurva = GameObject.Find("EfeitoChute").GetComponentInChildren<Slider>();
    }

    public void BallConstructor(Vector3 aInitPos)
    {
        SetInitPos(aInitPos);
        SetPosition(aInitPos);
    }

    public void SetPosition(Vector3 aPosition)
    {
        transform.position = aPosition;
    }

    public void SetInitPos(Vector3 aInitPos)
    {
        initPos = aInitPos;
    }


    public void ChangePowerFoward(float x)
    {

        
        Debug.Log("Opalala");
        this.powerFoward = x * 6000;
        Debug.Log(this.powerFoward);

    }

    public void ChangePowerUp(float powerUp)
    {
        this.powerUp = powerUp;
    }

    public void ChangePowerRight(float powerRight)
    {
        this.powerRight = powerRight;
    }

    public void ChangePowerCurva(float powerCurva)
    {
        this.powerCurva = powerCurva;
    }



    // Update is called once per frame

    private void FixedUpdate()
    {
        if (powerFoward == 0 && powerUp == 0 && powerRight == 0 && powerCurva == 0)
        {
            shoot = false;
        }

        if (curva > 0 && shoot)
        {
            Curva();
        }

        
    }
    void Update()
    {

        
    }

    private void OnMouseDown()
    {
       
        //if (touchShoot)
        //{
            ShootBall();
       // }
        
        
    }

    private void ShootBall()
    {
        if (!shoot)
        {
            shoot = true;
            efeito = true;

            powerFoward = slidePowerFoward.value * 3000;
            powerUp = slidePowerUp.value * 1000;
            powerRight = (slidePowerRight.value - 0.5f) * 2000;           
            powerCurva = slidePowerCurva.value * 1000;



            Vector3 forca = new Vector3(powerRight, powerUp, powerFoward);
            body.AddForce(forca);
            curva = powerCurva;

        }
    }


    public void ShootTest(Vector4 vectorShoot)
    {
        if (!shoot)
        {
            float f, u, r, c;

            f = vectorShoot.x;
            u= vectorShoot.y;
            r = vectorShoot.z;
            c = vectorShoot.w;

            shoot = true;
            efeito = true;

            powerFoward = f * 3000;
            powerUp = u * 1000;
            powerRight = r * 2000;           
            powerCurva = c * 1000;



            Vector3 forca = new Vector3(powerRight, powerUp, powerFoward);
            body.AddForce(forca);
            curva = powerCurva;

        }
    }



    private void Curva()
    {
        if (efeito)
        {
            body.AddForce(-Vector3.right * (powerRight / 100));            
            curva--;
        } 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 && shoot)
        {
            efeito = false;
        }
    }

    


        public void Restart()
    {
        
        powerFoward = 0;
        powerUp = 0;
        powerRight = 0;
        powerCurva = 0;

        efeito = true;


        transform.position = initPos;

        body.velocity = new Vector3(0, 0, 0);

        body.angularVelocity = new Vector3(0, 0, 0);

    }

    public bool CanShoot()
    {
        return !shoot;

    }
}
