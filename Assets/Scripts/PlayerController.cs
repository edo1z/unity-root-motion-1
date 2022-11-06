using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Settings
    public float Speed = 0.5f;
    public float TurnSpeedX = 0.5f; // TODO Gamepad‚¾‚Æ’x‚¢
    public float TurnSpeedY = 0.2f; // TODO Gamepad‚¾‚Æ’x‚¢

    // Objects
    public Transform cameraFollowTarget;
    private Animator anim;
    private PlayerInputsHandler inputs;

    // States
    private Vector2 currentVelocity;

    private void Awake()
    {
        anim = transform.GetComponentInChildren<Animator>();
        inputs = GetComponent<PlayerInputsHandler>();
    }

    private void Aim()
    {
        // …•½•ûŒü
        Vector2 rotationInput = inputs.GetLook();
        Vector3 rotation = transform.eulerAngles;
        rotation.y += rotationInput.x * TurnSpeedX;
        transform.rotation = Quaternion.Euler(rotation);

        // ‚’¼•ûŒü
        rotation = cameraFollowTarget.localRotation.eulerAngles;
        rotation.x -= rotationInput.y * TurnSpeedY;
        if (rotation.x > 180) rotation.x -= 360;
        rotation.x = Mathf.Clamp(rotation.x, -85, 85);
        cameraFollowTarget.localRotation = Quaternion.Euler(rotation);
    }

    private void Move()
    {
        Vector2 direction = inputs.GetMove();
        float speed = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);
        speed = Mathf.Clamp(speed, 0f, 1f);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref currentVelocity.y, 0.2f);
        bool isSprinting = inputs.GetSprint() && direction.y > 0.1f;
        anim.SetFloat("Speed", speed);
        anim.SetFloat("DirectionX", direction.x);
        anim.SetFloat("DirectionY", direction.y);
        anim.SetBool("IsSprinting", isSprinting);
    }

    private void FixedUpdate()
    {
        Aim();
        Move();
    }
}
