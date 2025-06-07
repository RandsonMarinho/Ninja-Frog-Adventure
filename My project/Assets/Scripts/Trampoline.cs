using UnityEngine;

/// <summary>
/// Handles trampoline behavior: animates and launches the player upward on contact.
/// </summary>

public class Trampoline : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Animator component for the trampoline animation.")]
    public Animator anim;

    [Tooltip("Audio GameObject that plays when the trampoline is activated.")]
    public GameObject trampolineAudio;

    /// <summary>
    /// Activates the trampoline animation, plays audio, and launches the player upwards.
    /// </summary>
    /// <param name="collision">Collision data from the 2D physics system.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("trampolin", true);
            collision.rigidbody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);

            GameObject obj = Instantiate(trampolineAudio, transform.position, Quaternion.identity);
            Destroy(obj, 1);
        }
    }


    /// <summary>
    /// Deactivates the trampoline animation when the player leaves the trampoline.
    /// </summary>
    /// <param name="collision">Collision data from the 2D physics system.</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("trampolin", false);
        }
    }
}
