using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    // Checks when items are added/removed
    public delegate void OnItemChanged(); // subscribable event
    public OnItemChanged onItemChangedCallback; // implements delegate

    public List<Item> items = new List<Item>(); // creates a new list for items
    int space = 20;

    /// <summary>
    /// Adds item to the list
    /// </summary>
    /// <param name="item"></param>
    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false; // returns false so item does not get destroyed
        }
        else
        {
            items.Add(item);
            Debug.Log(items.Count);

            // used for UI updating
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke(); // triggers event for UI update
            }

            return true;
        }
    }

    /// <summary>
    /// Removes item from the list
    /// </summary>
    /// <param name="item"></param>
    public void Remove(Item item)
    {
        items.Remove(item);

        // used for UI updating
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke(); // triggers event for UI update
        }
    }
}
