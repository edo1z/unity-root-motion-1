using UnityEngine;

public class Weapon : Item
{
  public AnimationClip weaponAnimation;

  private void Awake()
  {
    ItemType = Type.Weapon;
  }
}
