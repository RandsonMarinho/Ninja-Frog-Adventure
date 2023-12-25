using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
/* DECLARANDO UMA VARI�VEL PARA USAR NA ANIMA��O DO FOGO E OUTRA PARA SER O COLISOR QUE CAUSAR� DANO AO PLAYER
--------------------------------------------------------------------------------------------------------------*/
    public Animator anim;
    public GameObject hitBox;


/*                            CRIANDO UMA COROUTINE PARA ATIVAR O FOGO 
--------------------------------------------------------------------------------------------------------------*/
    IEnumerator SetFire()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("fire", true);
        yield return new WaitForSeconds(0.2f);
        hitBox.SetActive(true);
    }


/*       CHAMANDO O M�TODO DE ATIVAR O FOGO QUANDO O PLAYER COLIDIR COM O OBJETO
--------------------------------------------------------------------------------------------------------------*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(SetFire());
        }
    }
}

