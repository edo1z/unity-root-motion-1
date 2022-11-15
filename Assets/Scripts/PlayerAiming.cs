using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAiming : MonoBehaviour
{
  // Settings
  public float TurnSpeedX = 0.5f; // TODO Gamepad���ƒx��
  public float TurnSpeedY = 0.2f; // TODO Gamepad���ƒx��
  public float aimDuration = 0.3f;

  // Objects
  public Transform cameraFollowTarget;
  public Rig weaponAiming;
  // public GameObject laser;
  private PlayerInputsHandler inputs;
  private ActiveWeapon activeWeapon;

  private void Awake()
  {
    inputs = GetComponent<PlayerInputsHandler>();
    activeWeapon = GetComponent<ActiveWeapon>();
  }

  private void Start()
  {
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void Aim()
  {
    // ��������
    Vector2 rotationInput = inputs.GetLook();
    Vector3 rotation = transform.eulerAngles;
    rotation.y += rotationInput.x * TurnSpeedX;
    transform.rotation = Quaternion.Euler(rotation);

    // ��������
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
    //if (activeWeapon.weapon && inputs.GetFire() && weaponAiming.weight < 1f)
    //{
    //    weaponAiming.weight += Time.deltaTime / aimDuration;
    //}
    //else if (!activeWeapon.weapon || (!inputs.GetFire() && weaponAiming.weight > 0))
    //{
    //    weaponAiming.weight -= Time.deltaTime / aimDuration;
    //}
    weaponAiming.weight = 1f;

    // �e�̃��[�U�\����ON/OFF
    // if (activeWeapon.weapon && weaponAiming.weight > 0.5f)
    // {
    //     laser.SetActive(true);
    // }
    // else
    // {
    //     laser.SetActive(false);
    // }
  }
}
