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

    private void FixedUpdate()
    {
        Vector2 direction = inputs.GetMove();
        float speed = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        speed = Mathf.Clamp(speed, 0f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref currentVelocity.y, 0.2f);
        anim.SetFloat("Speed", speed);
        anim.SetFloat("DirectionX", direction.x);
        anim.SetFloat("DirectionY", direction.y);
    }
}
