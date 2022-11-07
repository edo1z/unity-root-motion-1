using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
    // Settings
    public float TurnSpeedX = 0.5f; // TODO Gamepad‚¾‚Æ’x‚¢
    public float TurnSpeedY = 0.2f; // TODO Gamepad‚¾‚Æ’x‚¢
    public float aimDuration = 0.3f;

    // Objects
    public Transform cameraFollowTarget;
    public Rig weaponAiming;
    public GameObject laser;
    private PlayerInputsHandler inputs;

    private void Awake()
    {
        inputs = GetComponent<PlayerInputsHandler>();
    }

    public void Aim()
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

    private void FixedUpdate()
    {
        Aim();
    }

    private void Update()
    {
        if (inputs.GetFire() && weaponAiming.weight < 1f)
        {
            weaponAiming.weight += Time.deltaTime / aimDuration;
        }
        else if (!inputs.GetFire() && weaponAiming.weight > 0)
        {
            weaponAiming.weight -= Time.deltaTime / aimDuration;
        }

        // e‚ÌƒŒ[ƒU•\Ž¦‚ÌON/OFF
        if (weaponAiming.weight > 0.5f)
        {
            laser.SetActive(true);
        }
        else
        {
            laser.SetActive(false);
        }
    }
}
