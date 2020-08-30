using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastListener : MonoBehaviour
{
    public static BroadcastListener Instance { get; private set;}
    

    private void Awake()
    {
        if(Instance == null)
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
        //scoreGame = new ScoreGame();
    }

    public void TestListener(float t)
    {
        Debug.Log(t);
    }

    public void Linten(string command, float value)
    {
        switch (command)
        {
            case "addScore":
                print("Add score");
                AddToScoreGame(value);
                break;

            case "subScore":
                print("Sub Score");
                SubToScoreGame(value);
                break;

            default:
                print("Incorrect command");
                break;
        }
    }

    //____________________________Pontuação______________________

    void AddToScoreGame(float f)
    {
        ScoreGame.Instance.AddScore(f);
        ScoreGame.Instance.DebugScore();
    }

    void SubToScoreGame(float f)
    {
        ScoreGame.Instance.SubScore(f);
        ScoreGame.Instance.DebugScore();
    }
}
