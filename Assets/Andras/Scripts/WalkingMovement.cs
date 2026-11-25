using UnityEngine;
using UnityEngine.InputSystem;

public class WalkingMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed = 8f;
    public float jumpHeight = 15f;

    private float movement;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.linearVelocityX = movement;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<Vector2>().x * speed;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            rb2d.linearVelocityY = jumpHeight;
        }
    }
}
