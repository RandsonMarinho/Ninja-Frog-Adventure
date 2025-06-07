using UnityEngine;

/// <summary>
/// Causes the platform to fall shortly after the player steps on it.
/// </summary>

public class FallingPlataform : MonoBehaviour
{
    #region Components

    [Header("References")]
    [Tooltip("BoxCollider2D of the platform.")]
    public BoxCollider2D boxCollider;

    [Tooltip("TargetJoint2D responsible for holding the platform in place.")]
    public TargetJoint2D joint;

    #endregion

    #region Unity Events

    /// <summary>
    /// Detects when the player lands on the platform and schedules the fall.
    /// </summary>
    /// <param name="collision">Collision information from the 2D physics system.</param>
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(Falling), 0.1f);
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Disables the platform's collider and joint, making it fall.
    /// </summary>

    void Falling()
    {
        boxCollider.enabled = false;
        joint.enabled = false;
    }

    #endregion
}
