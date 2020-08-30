using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScoreGame : MonoBehaviour
{
    public static ScoreGame Instance { get; private set; }

    private float score;
    public float Score
    {
        get { return score; }
    }

    private GameController gameController;
    



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        score = 0f;
        gameController = gameObject.GetComponentInParent<GameController>();
        
    }

    public void Restart()
    {
        score = 0f;
    }

    public void AddScore(float s)
    {

        AddScoreGameController(s);

        score += s;
    }

    public void SubScore(float s)
    {
        score -= s;
    }

    public void DebugScore()
    {
        Debug.Log(score);
    }

    public float GetScore()
    {
        return Score;
    }

    private void AddScoreGameController(float s)
    {
        gameController.shootManager.AddScoreTry(s);

    }


}
