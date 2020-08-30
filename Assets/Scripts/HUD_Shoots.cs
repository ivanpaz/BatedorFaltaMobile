using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Shoots : MonoBehaviour
{
    [SerializeField]
    GameController gamecontroller;
    [SerializeField]
    Color usedColor, unusedColor;

    [Header("Imagem 1")]
    [SerializeField]
    private Image try1Image;
    [SerializeField]
    private Text try1Text;


    [Header("Imagem 2")]
    [SerializeField]
    private Image try2Image;
    [SerializeField]
    private Text try2Text;


    [Header("Imagem 3")]
    [SerializeField]
    private Image try3Image;
    [SerializeField]
    private Text try3Text;


    [Header("Imagem 4")]
    [SerializeField]
    private Image try4Image;
    [SerializeField]
    private Text try4Text;


    [Header("Imagem 5")]
    [SerializeField]
    private Image try5Image;
    [SerializeField]
    private Text try5Text;


    // Start is called before the first frame update
    void Start()
    {
        gamecontroller.SetHud_Shoot(this);
    }

    public void ActivateTry(int num)
    {
        
        switch (num)
        {
            case 1:
                try1Image.GetComponentInChildren<Image>().color = usedColor;
                break;

            case 2:
                try2Image.GetComponentInChildren<Image>().color = usedColor;
                break;

            case 3:
                try3Image.GetComponentInChildren<Image>().color = usedColor;
                break;

            case 4:
                try4Image.GetComponentInChildren<Image>().color = usedColor;
                break;

            case 5:
                try5Image.GetComponentInChildren<Image>().color = usedColor;
                break;

            default:
                print("Não tem essa quantidade de trys na hud");
                break;
        }
    }

    public void ReactiveTrys()
    {
        try1Image.color = unusedColor;
        try2Image.color = unusedColor;
        try3Image.color = unusedColor;
        try4Image.color = unusedColor;
        try5Image.color = unusedColor;
    }


    public void SetTryScore(int num, float score)
    {

        switch (num)
        {
            case 1:
                try1Text.text = score + "pts";
                break;

            case 2:
                try2Text.text = score + "pts";
                break;

            case 3:
                try3Text.text = score + "pts";
                break;

            case 4:
                try4Text.text = score + "pts";
                break;

            case 5:
                try5Text.text = score + "pts";
                break;

            default:
                print("Não tem essa quantidade de trys para Score na hud");
                break;
        }
    }

    public void ResetTryScore()
    {
        try1Text.text = "";
        try2Text.text = "";
        try3Text.text = "";
        try4Text.text = "";
        try5Text.text = "";
    }


    public void ActivateHud()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void DesactivateHud()
    {
        GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }
}
