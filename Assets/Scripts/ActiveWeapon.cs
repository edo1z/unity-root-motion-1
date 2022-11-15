using UnityEngine;
using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
  public Transform crossHairTarget;
  public UnityEngine.Animations.Rigging.Rig handIk;
  public Transform weaponParent;
  public Transform weaponRightGrip;
  public Transform weaponLeftGrip;

  public Weapon weapon;
  private Animator anim;
  private AnimatorOverrideController overrides;

  private void Start()
  {
    anim = GetComponent<Animator>();
    overrides = anim.runtimeAnimatorController as AnimatorOverrideController;
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
      anim.SetLayerWeight(1, 0f);
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
    anim.SetLayerWeight(1, 1f);
    overrides["weapon_anim_empty"] = weapon.weaponAnimation;
  }

  [ContextMenu("Save weapon pose")]
  private void SaveWeaponPose()
  {
    GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
    recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
    recorder.BindComponentsOfType<Transform>(weaponRightGrip.gameObject, false);
    recorder.BindComponentsOfType<Transform>(weaponLeftGrip.gameObject, false);
    recorder.TakeSnapshot(0f);
    recorder.SaveToClip(weapon.weaponAnimation);
    UnityEditor.AssetDatabase.SaveAssets();
  }
}
