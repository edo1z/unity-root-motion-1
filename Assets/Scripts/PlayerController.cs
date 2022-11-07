using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Settings
    public float Speed = 0.5f;

    // Objects
    private Animator anim;
    private PlayerInputsHandler inputs;

    // States
    private Vector2 currentVelocity;

    private void Awake()
    {
        anim = transform.GetComponentInChildren<Animator>();
        inputs = GetComponent<PlayerInputsHandler>();
    }

    private void Move()
    {
        Vector2 direction = inputs.GetMove();
        float speed = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        speed = Mathf.Clamp(speed, 0f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref currentVelocity.y, 0.2f);
        bool isSprinting = inputs.GetSprint() && direction.y > 0.1f;

        // Set animator
        anim.SetFloat("Speed", speed);
        anim.SetFloat("DirectionX", direction.x);
        anim.SetFloat("DirectionY", direction.y);
        anim.SetBool("IsSprinting", isSprinting);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
