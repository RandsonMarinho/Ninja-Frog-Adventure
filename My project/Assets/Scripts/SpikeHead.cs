using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
/*       DECLARANDO UMA VARIÁVEL PARA SER USADA COMO O CORPO DO OBJETO 
--------------------------------------------------------------------------------------------------------------*/
    public Rigidbody2D spkH;


/*       DETECTANDO COLISÃO ENTRE O OBJETO, O CHÃO E A MARGEM E ADICIONA-LO UMA FORÇA ESPECÍFICA
--------------------------------------------------------------------------------------------------------------*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            spkH.AddForce(Vector2.up * 200);
        }

        if (collision.gameObject.layer == 7)
        {
            spkH.AddForce(Vector2.down * 200);
        }
    }
}
