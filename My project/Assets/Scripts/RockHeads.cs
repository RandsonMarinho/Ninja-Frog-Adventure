using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeads : MonoBehaviour
{
 /*       DECLARANDO VARIÁVEIS PARA SEREM O CORPO DE CADA PEDRA
--------------------------------------------------------------------------------------------------------------*/
    public Rigidbody2D rh1;
    public Rigidbody2D rh2;
    public Rigidbody2D rh3;
    public Rigidbody2D rh4;
    public Rigidbody2D rh5;
    public Rigidbody2D rh6;
    public Rigidbody2D rh7;



/*       CRIANDO UMA COROUTINE PARA FAZER TODAS AS PEDRAS CAIREM EM INTERVALOS DE TEMPO
--------------------------------------------------------------------------------------------------------------*/
    IEnumerator Rock()
    {
        yield return new WaitForSeconds(1.2f);
        rh1.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        rh2.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        rh3.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        rh4.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        rh5.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        rh6.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.5f);
        rh7.gravityScale = 1.0f;
    }


/*       FAZENDO AS PEDRAS CAIREM QUANDO O PLAYER ESTIVER NUMA CERTA POSIÇÃO
--------------------------------------------------------------------------------------------------------------*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Rock());
        }
    }
}
