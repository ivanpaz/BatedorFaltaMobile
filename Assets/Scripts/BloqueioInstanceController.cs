using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueioInstanceController : ChallengeInstanceControler
{
    [SerializeField] GameObject outiline;
    [SerializeField] MeshRenderer myObj;

    public override void InitInstance(){
        //Inicia uma instancia (resetando os valores)
        StartAnimation();
        myObj.enabled = true;
        outiline.SetActive(false);
    }

    internal override void OnColide (){
        //Executa algo quando for colidido
    }

    internal override void setAnimationTransition(float value){
        transform.localScale = new Vector3(1, value, 1);
    }

    public void DesativateActivate (bool status){
        //ToDO - Desativar o objeto da forma correta
        myObj.enabled = !status;
        outiline.SetActive(status);
    }
}
