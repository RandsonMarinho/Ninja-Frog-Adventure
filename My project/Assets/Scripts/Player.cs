using System.Collections;
using UnityEngine;

/// <summary>
/// Controla movimentação, pulo, colisões e eventos do jogador.
/// </summary>
public class Player : MonoBehaviour
{
    #region Atributes
    [Header("Atributos")]
    public float speed;
    public float jumpForce;
    public int life;
    #endregion

    #region Components
    [Header("Components")]
    private Vector2 direction;
    public Rigidbody2D rb;
    public Animator anim;
    public Animator endPointAnim;
    public GameObject cameraObj;
    public GameObject wall;
    public GameObject jumpAudio;
    public GameObject doubleJumpAudio;
    public GameObject backgroundAudio;
    public GameObject hitAudio;
    public GameObject winAudio;
    #endregion

    #region States
    public bool isGrounded;
    public bool isJumping;
    public bool doubleJump;
    private bool isHit;
    #endregion

    #region UI
    [Header("UI")]
    public GameObject gameOver;
    public GameObject winGame;
    #endregion

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        HandleAnimation();
        HandleJump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isGrounded = true;
            doubleJump = false;
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("FPlatform"))
        {
            transform.parent = collision.transform;
        }
        
        if (collision.gameObject.CompareTag("Hit"))
        {
            isHit = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FPlatform"))
        {
            transform.parent = null;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.tag)
        {
            case "cp1": SetCameraPosition(new Vector3(0, 0, -10)); break;
            case "cp2": SetCameraPosition(new Vector3(17.67f, 0, -10)); break;
            case "cp3": SetCameraPosition(new Vector3(35.55f, 0, -10)); break;
            case "cp4": SetCameraPosition(new Vector3(51.60f, 0, -10)); break;
            case "cp5": SetCameraPosition(new Vector3(67.60f, 0, -10)); break;
            case "cp6": SetCameraPosition(new Vector3(83.8f, 0, -10)); wall.SetActive(true); break;
            case "cp7": SetCameraPosition(new Vector3(99.50f, 0, -10)); wall.SetActive(true); break;
            case "EndPoint": StartCoroutine(Win()); break;
            case "Hit": isHit = true; break;
        }
    }

    #region Métodos Auxiliares

    private void SetCameraPosition(Vector3 position)
    {
        cameraObj.transform.position = position;
    }

    private void Move()
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump(jumpForce, jumpAudio);
                isJumping = true;
                isGrounded = false;
            }
            else if (isJumping)
            {
                Jump(jumpForce, doubleJumpAudio);
                anim.SetInteger("transition", 3);
                doubleJump = true;
                isJumping = false;
            }
        }
    }

    private void Jump(float force, GameObject audio)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        GameObject sound = Instantiate(audio, transform.position, Quaternion.identity);
        Destroy(sound, 1f);
    }

    private void HandleAnimation()
    {
        if (isHit)
        {
            StartCoroutine(Disappear());
            return;
        }

        if (!isGrounded)
        {
            anim.SetInteger("transition", doubleJump ? 3 : 2);
        }
        else
        {
            if (direction.x == 0)
                anim.SetInteger("transition", doubleJump ? 3 : 0);
            else
                anim.SetInteger("transition", doubleJump ? 3 : 1);
        }

        if (direction.x != 0)
            transform.eulerAngles = new Vector3(0, direction.x > 0 ? 0 : 180, 0);
    }

    private IEnumerator Win()
    {
        endPointAnim.SetBool("transition", true);
        StopPlayer();
        Destroy(backgroundAudio);
        winAudio.SetActive(true);
        yield return new WaitForSeconds(5f);
        winGame.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator Disappear()
    {
        Destroy(backgroundAudio);
        hitAudio.SetActive(true);
        anim.SetInteger("transition", 4);
        StopPlayer();
        yield return new WaitForSeconds(0.8f);
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private void StopPlayer()
    {
        speed = 0;
        jumpForce = 0;
    }
    #endregion
}
