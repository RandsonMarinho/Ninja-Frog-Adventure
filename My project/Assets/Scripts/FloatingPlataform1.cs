using UnityEngine;

/// <summary>
/// Controls the movement of a floating platform while the player is standing on it.
/// </summary>

public class FloatingPlataform1 : MonoBehaviour
{
    #region Atributes

    [Header("Settings")]
    [Tooltip("The speed at which the platform moves along the X-axis")]
    public float speed = 3f;

    [Tooltip("The maximum X position the platform can reach.")]
    public float maxX = 29f;

    #endregion

    #region Unity Events

    /// <summary>
    /// Moves the platform to the right as long as the player stays on it.
    /// </summary>
    /// <param name="collision">Collision information from the 2D physics system.</param>     
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.CompareTag("Player") && transform.position.x <= maxX)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    #endregion
}
