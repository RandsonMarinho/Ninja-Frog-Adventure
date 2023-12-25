using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
/*       DECLARANDO UMA VARI�VEL PARA SER USADA COMO O CORPO DO OBJETO 
--------------------------------------------------------------------------------------------------------------*/
    public Rigidbody2D spkH;


/*       DETECTANDO COLIS�O ENTRE O OBJETO, O CH�O E A MARGEM E ADICIONA-LO UMA FOR�A ESPEC�FICA
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
