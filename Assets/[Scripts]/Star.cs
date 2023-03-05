using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] float force;

    // Shoot Star in upward direction with some randomness in angle, and destroy it after 5 seconds...
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-0.25f, 0.25f), force, 0), ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }
}
