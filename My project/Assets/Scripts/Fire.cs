using System.Collections;
using UnityEngine;

/// <summary>
/// Controls the fire trap animation and enables its hitbox when the player touches it.
/// </summary>
public class Fire : MonoBehaviour
{
    #region Components

    [Header("References")]
    [Tooltip("Animator responsible for the fire animation.")]
    public Animator anim;

    [Tooltip("Hitbox that deals damage to the player.")]
    public GameObject hitBox;

    #endregion

    #region Unity Events

    /// <summary>
    /// Triggers the fire trap when the player collides with it.
    /// </summary>
    /// <param name="collision">Collision data from the physics engine.</param>
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetFire());
        }
    }

    #endregion

    #region Coroutine

    /// <summary>
    /// Coroutine that plays the fire animation and enables the hitbox after short delays.
    /// </summary>
    private IEnumerator SetFire()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("fire", true);
        yield return new WaitForSeconds(0.2f);
        hitBox.SetActive(true);
    }
    #endregion
}

