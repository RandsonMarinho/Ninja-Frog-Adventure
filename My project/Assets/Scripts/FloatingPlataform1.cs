using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlataform1 : MonoBehaviour
{
/*       DECLARANDO UMA VARIÁVEL PARA SER USADA COMO A VELOCIDADE DA PLATAFORMA FLUTUANTE
--------------------------------------------------------------------------------------------------------------*/
    public float speed = 3f;
    
   
/*      FAZENDO A PLATAFORMA SE MOVER QUANDO O PLAYER ESTIVER EM CIMA
--------------------------------------------------------------------------------------------------------------- */      
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.x <= 29)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
        }
    }
}
