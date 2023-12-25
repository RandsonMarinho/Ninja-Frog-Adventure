using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
/*                                     ORGANIZANDO AS VARIÁVEIS DO SCRIPT
----------------------------------------------------------------------------------------------------------------- */                      
    [Header("Atributes")]
    public float speed;
    public float jumpForce;
    public int life;

    [Header("Components")]
    private Vector2 direction;
    public Rigidbody2D rb;
    public Animator anim;
    public Animator endPointAnim;
    public GameObject cameraobj;
    public GameObject wall;
    public GameObject jumpAudio;
    public GameObject doubleJumpAudio;
    public GameObject backgroundAudio;
    public GameObject hitAudio;
    public GameObject winAudio;
    private bool isGrounded;
    private bool isJumping;
    private bool doubleJump;
    private bool isHIt;
    

    [Header("UI")]
    public GameObject gameOver;
    public GameObject winGame;

/*                                    MANIPULAÇÃO DOS MÉTODOS DA UNITY
--------------------------------------------------------------------------------------------------------------*/                                     

    
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Anim();
        Jump();
    }

    private void FixedUpdate()
    {
        Mov();
    }

/*                            MANIPULANDO MÉTODOS DA UNITY QUE DETECTAM COLISÕES
--------------------------------------------------------------------------------------------------------------*/                           

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
            doubleJump = false;
        }

        if (collision.gameObject.tag == "FPlatform")
        {
            gameObject.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Hit")
        {
            isHIt = true;       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "cp1")
        {
            cameraobj.gameObject.transform.position = new Vector3(0, 0, -10);
        }

        if (collision.gameObject.tag == "cp2")
        {
            cameraobj.gameObject.transform.position = new Vector3(17.67f, 0, -10);

        }

        if (collision.gameObject.tag == "cp3")
        {
            cameraobj.gameObject.transform.position = new Vector3(35.55f, 0, -10);

        }

        if (collision.gameObject.tag == "cp4")
        {
            cameraobj.gameObject.transform.position = new Vector3(51.60f, 0, -10);

        }

        if (collision.gameObject.tag == "cp5")
        {
            cameraobj.gameObject.transform.position = new Vector3(67.60f, 0, -10);

        }

        if (collision.gameObject.tag == "cp6")
        {
            cameraobj.gameObject.transform.position = new Vector3(83.8f, 0, -10);
            wall.SetActive(true);

        }

        if (collision.gameObject.tag == "cp7")
        {
            cameraobj.gameObject.transform.position = new Vector3(99.50f, 0, -10);
            wall.SetActive(true);

        }

        if (collision.gameObject.tag == "EndPoint")
        {
            StartCoroutine(Win());
        }
    }
/*                                       CRIAÇÃO DOS COROUTINES    
-------------------------------------------------------------------------------------------------------------- */


//                          COROUTINE À SER EXECUTADO QUANDO O PLAYER VENCER O JOGO                                           

    IEnumerator Win()
    {
        endPointAnim.SetBool("transition", true);
        speed = 0;
        jumpForce = 0;
        Destroy(backgroundAudio.gameObject);
        winAudio.SetActive(true);
        yield return new WaitForSeconds(5);
        winGame.SetActive(true);
        Time.timeScale = 0;
    }

//                            COROUTINE À SER CHAMADO QUANDO O PLAYER FALHAR       

    IEnumerator Disappear()
    {
        Destroy(backgroundAudio.gameObject);
        hitAudio.SetActive(true);
        anim.SetInteger("transition", 4);
        speed = 0;
        jumpForce = 0;

        yield return new WaitForSeconds(0.8f);
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
     
/*                                       CRIAÇÃO DOS MÉTODOS 
---------------------------------------------------------------------------------------------------------------- */                                   


//                      MÉTODO PARA FAZER O PLAYER SE MOVER
    void Mov()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

//                      MÉTODO PARA FAZER O PLAYER PULAR
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                GameObject obj = Instantiate(jumpAudio, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Destroy(obj.gameObject, 1);
                isJumping = true;
                isGrounded = false;
            }
            else
            {
                if (isJumping)
                {
                    rb.AddForce(new Vector2(0f, jumpForce * 1.5f), ForceMode2D.Impulse);
                    GameObject obj = Instantiate(doubleJumpAudio, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                    Destroy(obj.gameObject, 1);
                    anim.SetInteger("transition", 3);
                    doubleJump = true;
                    isJumping = false;
                }
            }
        }
    }

//                 MÉTODO PARA EXECUTAR CADA ANIMAÇÃO DO PLAYER NO MOMENTO CORRETO
    void Anim()
    {
        if (direction.x > 0)
        {
            if (isGrounded)
            {
                anim.SetInteger("transition", 1);
                if (doubleJump)
                {
                    anim.SetInteger("transition", 3);
                }
            }
            transform.eulerAngles = Vector2.zero;
        }

        if (direction.x < 0)
        {
            if (isGrounded)
            {
                anim.SetInteger("transition", 1);
                if (doubleJump)
                {
                    anim.SetInteger("transition", 3);
                }
            }
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (direction.x == 0)
        {
            if (isGrounded)
            {
                anim.SetInteger("transition", 0);
                if (doubleJump)
                {
                    anim.SetInteger("transition", 3);
                }
            }
        }

        if (!isGrounded)
        {
            anim.SetInteger("transition", 2);
            if (doubleJump)
            {
                anim.SetInteger("transition", 3);
            }
        }

        if (isHIt)
        {
            StartCoroutine(Disappear());
        }
    }
}
