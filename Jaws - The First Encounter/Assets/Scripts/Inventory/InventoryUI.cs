using UnityEngine;

public class InventoryUI : MonoBehaviour
{ 
    public Transform itemsParent;
    InventorySlot[] slots; // array for slots

    public GameObject inventoryUI;
    Inventory inventory;

    /// <summary>
    /// Used for initialization
    /// </summary>
    //private void Start()
    //{
    //    inventory = Inventory.instance;
    //    inventory.onItemChangedCallback += UpdateUI;

    //    slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    //}

    /// <summary>
    /// Calls once per frame
    /// </summary>
    void Update()
    {
        // Opens and Closes inventory on button press
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

    }

    //void UpdateUI()
    //{
    //    // checks for available InventorySlots
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (i < inventory.items.Count)
    //        {
    //            slots[i].AddItem(inventory.items[i]);
    //        }
    //        else
    //        {
    //            slots[i].RemoveItem();
    //        }

    //    }
    //    Debug.Log("Updating UI");
    //}

}


