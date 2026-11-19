using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput))]
public class SwimmingMovement : MonoBehaviour
{
    // When the player presses any WASD, the player will move like normal.
    // The player will turn towards where they are moving, and return to normal when they stop. 

    private Rigidbody2D rb2d;

    public float speed;
    private float currentSpeed;

    private Vector2 movement;
    private Vector2 smoothMovement;
    private Vector2 smoothVelocity;
    [SerializeField] private float accelerationTime;

    [SerializeField] private float rotationSpeed;
    private float returnRotationSpeed = 180;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotatePlayer();
    }

    private void SetPlayerVelocity()
    {
        smoothMovement = Vector2.SmoothDamp(smoothMovement, movement, ref smoothVelocity, accelerationTime);
        rb2d.linearVelocity = smoothMovement * currentSpeed;
    }

    private void RotatePlayer()
    {
        if (movement != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMovement);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb2d.MoveRotation(rotation);
        } else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, returnRotationSpeed * Time.deltaTime);
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>();
    }
}
