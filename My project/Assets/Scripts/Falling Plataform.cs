using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlataform : MonoBehaviour
{
/*            CRIANDO UMA VARI�VEL PARA O CORPO DA PLATAFORMA, E OUTRA PARA SER UMA CARACTER�STICA DESTE CORPO
-----------------------------------------------------------------------------------------------------------------*/
            
    public BoxCollider2D boxCollider;
    public TargetJoint2D joint;


/*               CRIANDO UM M�TODO PARA FAZER A PLATAFORMA CAIR
--------------------------------------------------------------------------------------------------------------*/
    void Falling()
    {
        boxCollider.enabled = false;
        joint.enabled = false;
    }


/*       FAZENDO A PLATAFORMA CAIR QUANDO O PLAYER ESTIVER EM CIMA DELA
--------------------------------------------------------------------------------------------------------------*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", 0.1f);
        }
    }
}
