using System.Collections;
using UnityEngine;

/// <summary>
/// Triggers a sequence of falling rocks when the player collides with a specific object.
/// Each rock falls at a fixed interval.
/// </summary>

public class RockHeads : MonoBehaviour
{
    #region Rock References

    [Header("Rock Bodies")]
    [Tooltip("Rigidbody of Rock 1")]
    public Rigidbody2D rh1;

    [Tooltip("Rigidbody of Rock 2")]
    public Rigidbody2D rh2;

    [Tooltip("Rigidbody of Rock 3")]
    public Rigidbody2D rh3;

    [Tooltip("Rigidbody of Rock 4")]
    public Rigidbody2D rh4;

    [Tooltip("Rigidbody of Rock 5")]
    public Rigidbody2D rh5;

    [Tooltip("Rigidbody of Rock 6")]
    public Rigidbody2D rh6;

    [Tooltip("Rigidbody of Rock 7")]
    public Rigidbody2D rh7;

    #endregion

    #region Unity Events

    /// <summary>
    /// Starts the falling rock sequence when the player enters the trigger zone.
    /// </summary>
    /// <param name="collision">Collision data from the 2D physics system.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Rock());
        }
    }

    #endregion

    #region Coroutine

    /// <summary>
    /// Activates gravity on each rock at fixed time intervals to create a falling sequence.
    /// </summary>
    IEnumerator Rock()
    {
        float delay = 0.5f;

        yield return new WaitForSeconds(1.2f);
        rh1.gravityScale = 1f;

        yield return new WaitForSeconds(delay);
        rh2.gravityScale = 1f;

        yield return new WaitForSeconds(delay);
        rh3.gravityScale = 1f;

        yield return new WaitForSeconds(delay);
        rh4.gravityScale = 1f;

        yield return new WaitForSeconds(delay);
        rh5.gravityScale = 1f;

        yield return new WaitForSeconds(delay);
        rh6.gravityScale = 1f;

        yield return new WaitForSeconds(delay);
        rh7.gravityScale = 1f;
    }
    #endregion
}
