using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
/*                 DECLARANDO UMA VARIÁVEL PARA A ANIMAÇÃO DO TRAMPOLIM E OUTRA PARA O ÁUDIO
--------------------------------------------------------------------------------------------------------------*/
    public Animator anim;
    public GameObject trampolineAudio;


/*         IMPULSIONANDO O PLAYER QUANDO ENCOSTAR NO TRAMPOLIN, E ATIVANDO A ANIMAÇÃO DO TRAMPOLIM
--------------------------------------------------------------------------------------------------------------*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("trampolin", true);
            collision.rigidbody.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            GameObject obj = Instantiate(trampolineAudio, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
            Destroy(obj.gameObject, 1);
        }
    }


    /*       DESATIVANDO A ANIMAÇÃO DO TRAMPOLIN QUANDO O PLAYER PARAR DE ENCOSTAR NELE
    --------------------------------------------------------------------------------------------------------------*/
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("trampolin", false);
        }
    }
}
