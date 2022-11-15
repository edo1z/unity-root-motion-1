using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
  public Transform crossHairTarget;
  public UnityEngine.Animations.Rigging.Rig handIk;
  public Transform weaponParent;
  public Weapon weapon;

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
    if (!weapon)
    {
      handIk.weight = 0f;
    }
  }

  public void Equip(Weapon newWeapon)
  {
    Debug.Log("Equip!");

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
    handIk.weight = 1f;
  }
}
