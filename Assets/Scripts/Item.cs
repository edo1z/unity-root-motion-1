using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Weapon,
        Other
    }

    public Type ItemType;
    public string ItemName;
    public int Amount;
}
