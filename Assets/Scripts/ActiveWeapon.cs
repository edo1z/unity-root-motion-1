using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarget;
    public UnityEngine.Animations.Rigging.Rig handIk;
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
        weapon = newWeapon;
        handIk.weight = 1f;
    }
}
