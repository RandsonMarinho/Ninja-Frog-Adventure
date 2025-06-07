using UnityEngine;

/// <summary>
/// Controls a spiked object that bounces between floor and ceiling based on collision layers.
/// </summary>

public class SpikeHead : MonoBehaviour
{
    [Header("Physics")]
    [Tooltip("Rigidbody2D of the spike object")]
    public Rigidbody2D spkH;

    /// <summary>
    /// Applies upward or downward force based on the layer the object collides with.
    /// </summary>
    /// <param name="collision">Collision data from the 2D physics system.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Layer 6 = Floor
        if (collision.gameObject.layer == 6)
        {
            spkH.AddForce(Vector2.up * 200f);
        }

        // Layer 7 = Ceiling or Limit
        if (collision.gameObject.layer == 7)
        {
            spkH.AddForce(Vector2.down * 200f);
        }
    }
}
