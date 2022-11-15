using System.Collections.Generic;
using UnityEngine;

public class ItemSearch : MonoBehaviour
{
  // Object
  private PlayerInputsHandler inputs;
  private ActiveWeapon activeWeapon;

  public List<Item> ItemList;

  private void Awake()
  {
    inputs = GetComponent<PlayerInputsHandler>();
    activeWeapon = GetComponent<ActiveWeapon>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Item"))
    {
      ItemList.Add(other.GetComponent<Item>());
      SortItemListByDistance();
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Item"))
    {
      ItemList.Remove(other.GetComponent<Item>());
      SortItemListByDistance();
    }
  }

  private void SortItemListByDistance()
  {
    if (ItemList.Count < 1) return;
    float min = 100000f;
    float distance;
    for (int i = 0; i < ItemList.Count; i++)
    {
      distance = Vector3.Distance(ItemList[i].transform.position, transform.position);
      if (distance < min)
      {
        min = distance;
        Item tmpObj = ItemList[0];
        ItemList[0] = ItemList[i];
        ItemList[i] = tmpObj;
      }

    }
  }

  private void Update()
  {
    bool pickup = inputs.GetPickup();
    if (pickup)
    {
      if (ItemList.Count > 0)
      {
        Item item = ItemList[0];
        if (item.ItemType == Item.Type.Weapon)
        {
          Weapon weapon = (Weapon)item;
          activeWeapon.Equip(weapon);
        }
      }
    }
  }
}
