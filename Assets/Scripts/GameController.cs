using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    private HUD_Shoots hud_shoots;

    public ShootManager shootManager;
    public ShootManager ShootManager { get; }

    


    private Ball ball;
    public Ball Ball
    {
        get { return ball; }
        set { ball = value; }
    }

    [SerializeField]
    private DrawManager drawManager;

    private float currCountdownValue;


    
    void Start()
    {
        shootManager = new ShootManager(5);        
        PrepareGame();
    }

   
    void Update()
    {
        if (!Ball)
        {
            Ball = GameObject.Find("Bola(Clone)").GetComponent<Ball>();
        }

        if (Input.GetKeyDown("space"))
        {
            
            shootManager.ShowAllScores();
            Debug.Log("Space");
            drawManager.AllowDraw();
            Ball.Restart();
        } 
    }

    public void SetHud_Shoot(HUD_Shoots hs)
    {
        hud_shoots = hs;
    }

    public HUD_Shoots GetHUD_Shoots()
    {
        return hud_shoots;
    }

    public void PrepareShoot(PositionsList positionList)
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = ((height * cam.aspect) * 0.8f);


        /*

        //float foward = positionList.LenghtLine/height;
        //NOVO FOWARD
        float foward = positionList.ListOfPositions.Count / 100f;
        //Debug.Log("height: "+ height);
        float curve = Mathf.Abs(positionList.WidhtLine/width);
        //Debug.Log("width: " + width);


        
        //Calculo da distancia do Init pro fim
        //float up = ((height / 2) - positionList.InitPoint.y) / height;

        //NOVO UP
        float up = positionList.LenghtLine / (height/2);

        up = up * 1f;
        //Debug.Log("GC - up: " + up);


        //Debug.Log("right: " + positionList.VerticalMedium + "/"+width);
        //Debug.Log("Screen.width  " +Screen.width);
        float right = positionList.VerticalMedium / width;
        right = right * 1.5f;
        //Debug.Log("GC - right: " + right);

        */
        //NOVO CODIGO


        float foward = positionList.ListOfPositions.Count / 100f;
        float up = positionList.LenghtLine / (height / 2);
        float right = positionList.WidhtLine/width;
        
        float curve = Mathf.Abs(positionList.VerticalMedium / width);
        //Debug.Log("curve:  " + curve);

        if (!Ball)
        {
            Ball = GameObject.Find("Bola(Clone)").GetComponent<Ball>();
        }
        Ball.PrepareShoot(foward, up, right, curve);
        Shoot();
        


    }

    public void RestartBall()
    {        
        Ball.Restart();
        drawManager.AllowDraw();
        GameObject.Find("Instantiate Challenge").GetComponent<CreateChallengeTest>().CreateChallenge();
    }

    public void Shoot()
    {
        hud_shoots.DesactivateHud();
        if (shootManager.TryShoot())
        {
            
            Ball.ShootBall();
            StartCoroutine(LoadingNextTry());

            
           hud_shoots.ActivateTry(shootManager.positionTry);
        }
        else
        {
            Debug.Log("Sem mais tentativas");
            shootManager.ShowAllScores();
            
        }
        
    }

   


    public IEnumerator LoadingNextTry(float countdownValue = 4)
    {
        currCountdownValue = countdownValue;
        //Debug.Log("Countdown: " + currCountdownValue);
        while (currCountdownValue > 0)
        {

            yield return new WaitForSeconds(1);
            currCountdownValue -= 1;
        }

        if (currCountdownValue <= 0)
        {
            if (shootManager.CanTry())
            {
                RestartBall();
                shootManager.AddScoreToHud(hud_shoots);
                hud_shoots.ActivateHud();
            }
            else
            {
                EndGame();
            }
            
        }
    }

    public void PrepareGame()
    {
        FinalPainel.Instance.DesactivateHud();
        hud_shoots.ResetTryScore();
        hud_shoots.ReactiveTrys();
        shootManager.Restart();
        ScoreGame.Instance.Restart();
        RestartBall();
    }

    private void EndGame()
    {
        FinalPainel.Instance.SetScore(ScoreGame.Instance.GetScore());
        FinalPainel.Instance.ActivateHud();
    }

}
