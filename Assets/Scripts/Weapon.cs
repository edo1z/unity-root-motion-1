using UnityEngine;

public class Weapon : Item
{
  public AnimationClip weaponAnimation;
  public string weaponCode;

  private void Awake()
  {
    ItemType = Type.Weapon;
  }
}
