using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic item class
/// </summary>
public class Item : MonoBehaviour
{
    public Sprite icon = null;

    protected int size;             // size of item as it relates to the ship's cargo capacity
    protected int buyValue;         // how much this item is worth to buy from merchants
    protected int sellValue;        // how much this item is worth to sell to merchants

    //// Handles usage of item
    //protected abstract void Use();

    //// Handles buying item from vendor
    //protected abstract void Buy();

    //// Handles selling item to vendor
    //protected abstract void Sell();

    //// Handles removal of item from hull
    //protected abstract void Remove();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
