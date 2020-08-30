using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    GameObject ballImage;

    //[SerializeField]
    float varFoward = 1000f;

    //[SerializeField]
    float varUp = 3000f;

    //[SerializeField]
    float varRight = 4000f;

    //[SerializeField]
    float varCurve = 12000f;

    //Variaveis encapsuladas
    [SerializeField]
    private Rigidbody body;
    public Rigidbody Body
    {
        get { return body; }
    }

    private float powerFoward; //Forca para frente
    public float PowerFoward 
    {
        get { return powerFoward; }
        set { powerFoward = value; }
    }


    private float powerUp; //Forca para cima
    public float PowerUp
    {
        get { return powerUp; }
        set { powerUp = value; }
    }

    private float powerRight; // Forca de abertura da acurva
    public float PowerRight
    {
        get { return powerRight; }
        set { powerRight = value; }
    }

    private float powerCurve; //Intensidade da Curva (testar melhor)
    private float PowerCurve
    {
        get { return powerCurve; }
        set { powerCurve = value; }
    }

    //--------------Fim as variaveis encapsuladas

    //Variaveis privadas
    private bool shoot = false; //Verifica se poder chutar
    private bool efeito = false; //Verifica se continua aplicando o efeito
    //private float resistenciaGrama = 0.2f;    
    private float curve = 0;
    private Vector3 initPos;
    public bool touchShoot = true;

    //------------------Fim das variaveis privadas

    //Construtor artifical da Classe
    public void BallConstructor(Vector3 aInitPos)
    {
        SetInitPos(aInitPos);
        SetPosition(aInitPos);
    }

    //-------------Fim do construtor

    private void Start()
    {
        //body = this.GetComponent<Rigidbody>();
        
    }

    // Update
    private void FixedUpdate()
    {
        if (powerFoward == 0 && powerUp == 0 && powerRight == 0 && powerCurve == 0)
        {
            shoot = false;
        }

        if (curve > 0 && shoot)
        {
            CurveEffect();
        }

        if(ballImage != null)
            RotateBallImage();
    }

    //------------Fim do Update


    // Funções
    //Funções de imagem da bola
    private void RotateBallImage()
    {
        ballImage.transform.Rotate(0, 0, getHorizontalVelocity());
    }
    private float getHorizontalVelocity()
    {
        if(Mathf.Abs(body.velocity.x) > .5f )
        {
            return body.velocity.x * 3;
        }

        return Mathf.Clamp(body.velocity.magnitude, 0, 10);
    }

    //Funções de Translado
    public void SetPosition(Vector3 aPosition)
    {
        transform.position = aPosition;
    }

    public void SetInitPos(Vector3 aInitPos)
    {
        initPos = aInitPos;
    }

    //---------------Fim de Funções de Translado


    //Funções de controle de parametros do chute

    public void PrepareShoot(float foward, float up, float right, float curve)
    {
        ChangePowerFoward(foward);
        ChangePowerUp(up);
        ChangePowerRight(right);
        ChangePowerCurve(curve);
    }

    private void ChangePowerFoward(float x)
    {
        //this.powerFoward = x * varFoward;
       
        this.powerFoward = varFoward + (x*1000f);


    }

    private void ChangePowerUp(float x)
    {
       // Debug.Log("Up: " + x + "    varUp: " + varUp);
        PowerUp = x * varUp;
        
    }

    private void ChangePowerRight(float powerRight)
    {

       
        this.powerRight = powerRight * varRight;
    }

    private void ChangePowerCurve(float powerCurve)
    {
        this.powerCurve = powerCurve * varCurve;
    }


    // -------------------- Fim Funções de controle de parametros do chute


    // Funções de chute e efeitos
    public void ShootBall()
    {

       
        if (!shoot)
        {           
            shoot = true;
            efeito = true;            
            Vector3 forca = new Vector3(powerRight, powerUp, powerFoward);
           // Debug.Log("Forcas" + forca);
            body.AddForce(forca);
            curve = powerCurve;
        }
    }


    private void CurveEffect()
    {
        if (efeito)
        {
            body.AddForce(-Vector3.right * (powerRight / 65));
            curve--;
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


        ChangePowerFoward(0);
        ChangePowerUp(0);
        ChangePowerRight(0);
        ChangePowerCurve(0);

        efeito = true;

        SetPosition(initPos);
        shoot = false;


        if (body)
        {
            body.velocity = new Vector3(0, 0, 0);

            body.angularVelocity = new Vector3(0, 0, 0);
        }
        

    }

    public bool CanShoot()
    {
        return !shoot;

    }
    // ------------------- Fim Funções de chute e efeitos







}
