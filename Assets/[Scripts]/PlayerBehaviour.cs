using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement Properties")]
    public float horizontalForce;
    public float maxSpeed;
    public float verticalForce;
    public float airFactor;
    public Transform groundPoint;
    public float groundRadius;
    public LayerMask groundLayerMask;
    public bool isGrounded;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    // Initialize Components
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump Input
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            Jump();

        // Duck Input & Animation
        _animator.SetBool("isDucking", Input.GetKey(KeyCode.S));
    }

    void FixedUpdate()
    {
        // Check if Player is on ground or not
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask);
        var x = Input.GetAxisRaw("Horizontal");
        _animator.SetBool("isGrounded", isGrounded);

        Flip(x);
        Move(x);
    }

    private void Move(float x)
    {
        // Add force to move player
        _rigidbody2D.AddForce(Vector2.right * x * horizontalForce * ((isGrounded) ? 1 : airFactor), ForceMode2D.Impulse);
        _rigidbody2D.velocity = new Vector2(Mathf.Clamp(_rigidbody2D.velocity.x, -maxSpeed, maxSpeed), _rigidbody2D.velocity.y);

        // Play Skipping animation
        if (isGrounded)
            _animator.SetFloat("xSpeed", Mathf.Abs(_rigidbody2D.velocity.x));
    }

    private void Jump()
    {
        // Add jumping force
        if (isGrounded)
            _rigidbody2D.AddForce(Vector2.up * verticalForce, ForceMode2D.Impulse);
    }

    // Flip the player in appropriate direction...
    private void Flip(float x)
    {
        if (x != 0)
            transform.localScale = new Vector3((x > 0) ? 1 : -1, 1, 1);
    }
}
