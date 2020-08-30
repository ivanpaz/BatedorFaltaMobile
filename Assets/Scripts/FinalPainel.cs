using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPainel : MonoBehaviour
{
    public static FinalPainel Instance { get; private set; }

    [SerializeField]
    private Text t;

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
        //DesactivateHud();
    }

    

    public void ActivateHud()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
    public void DesactivateHud()
    {
        GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    public void SetScore(float s)
    {
        t.text = s+"pts";
    }
}
