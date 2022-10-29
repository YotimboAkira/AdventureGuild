using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item Item;

    public void AddItem(Item newItem)
    {
        Item = newItem;
        icon.sprite = Item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        Item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
