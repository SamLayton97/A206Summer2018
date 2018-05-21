using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    Item item;

    /// <summary>
    /// Adds image to UI
    /// </summary>
    /// <param name="newItem"></param>
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    /// <summary>
    /// Removes image from UI
    /// </summary>
    public void RemoveItem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

}
