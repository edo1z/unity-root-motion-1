using UnityEngine;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
  public Transform crossHairTarget;
  public UnityEngine.Animations.Rigging.Rig handIk;
  public Transform weaponParent;
  public Transform weaponRightGrip;
  public Transform weaponLeftGrip;
  public Animator rigController;

  public Weapon weapon;

  private PlayerInputsHandler inputs;

  private void Awake()
  {
    inputs = GetComponent<PlayerInputsHandler>();
  }

  private void Start()
  {
    Weapon existingWeapon = GetComponentInChildren<Weapon>();
    if (existingWeapon)
    {
      Equip(existingWeapon);
    }
  }

  private void Update()
  {
    if (inputs.GetEquipToggle())
    {
      bool isHolstered = rigController.GetBool("holster_weapon");
      rigController.SetBool("holster_weapon", !isHolstered);
    }
  }

  public void Equip(Weapon newWeapon)
  {
    // 武器を複製
    Weapon newWeaponCopy = Instantiate(newWeapon);

    // 既に装備していたら削除
    if (weapon)
    {
      Destroy(weapon.gameObject);
    }

    weapon = newWeaponCopy;
    weapon.transform.parent = weaponParent;
    weapon.transform.localPosition = Vector3.zero;
    weapon.transform.localRotation = Quaternion.identity;
    rigController.Play("equip_" + weapon.weaponCode);
  }

}