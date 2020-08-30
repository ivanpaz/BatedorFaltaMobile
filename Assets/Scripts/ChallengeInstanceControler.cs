using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChallengeInstanceControler : BroadcastEmisser  
{
    [SerializeField] AnimationCurve colisionAnimation;
    [SerializeField] float animationTime;
    [SerializeField] LayerMask mask;
    [SerializeField] AudioClip audio;

    //Score
    [SerializeField] float points = 100f;
    //Tamanho 
    [SerializeField] float maxSize, minSize = 1;



    Vector3 position;
    float size = 1f; // Tamanho maximo e minimo

    bool checkCollision = true;         // Checar colisão
    bool canAnimate     = false;        // A area pode mudar de tamanho de acordo com o tempo
    bool hasCollided    = false;        // Já colidiu coim algo

    IEnumerator Animation(float animationTime)
    {
        float curveTime = 0;
        float size = transform.localScale.x;
        float transitionElapce = colisionAnimation.Evaluate(0);

        while (curveTime < animationTime)
        {
            //Timer
            curveTime += Time.deltaTime;
            float percent = curveTime / animationTime;
            float lerp = Mathf.Lerp(0, 1, percent);
            transitionElapce = colisionAnimation.Evaluate(lerp);
            setAnimationTransition((size * transitionElapce));
            yield return null;
        }
    }


    void OnEnable (){
        
        InitInstance();
    }
    
    void Update()
    {
        if (checkCollision)
        {
            if (!hasCollided)
            {
                Collider[] hitColliders = Physics.OverlapSphere(position, size, mask);
                if (hitColliders != null && hitColliders.Length > 0)
                {
                    Debug.Log($"Pegou a bola {hitColliders[0].name}");
                    OnColide();
                }
            }
        }
    }

    //Inicia a instancia
    public virtual void InitInstance()
    {
        float scaleArea = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(scaleArea, scaleArea, 1);
        position = transform.position;
        size = transform.localScale.y;
        hasCollided = false;
        checkCollision = true;    
    }

    //Muda o comportamento ao ser colidido
    internal virtual void OnColide()
    {
        hasCollided = true;
        //Listener.AddToScoreGame(10f);
        
        MakeSoundEffect();
        StartAnimation();


        BroadcastListener.Instance.Linten("addScore", points);
    }

    public void StartAnimation (){
        StartCoroutine(Animation(animationTime));
    }

    //Executa um comando com valores entre 1 ao infinito
    internal virtual void setAnimationTransition(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }

    //Executa o som
    void MakeSoundEffect()
    {
        SoundEffectController.metod.PlaySong(12, 100, audio);
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(position, size);
    }
    
}
