using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	public List<Item> inventory = new List<Item> ();

	/// <summary>
	/// Adds the item.
	/// </summary>
	/// <param name="item">Item.</param>
	public void AddItem(Item item)
	{
		// Adds item to the inventory
		this.inventory.Add (item);
	}

	/// <summary>
	/// Gets the inventory list.
	/// </summary>
	/// <returns>The inventory list.</returns>
	public string GetInventoryList()
	{
		// Lists all the items in inventory and constructs the inventory output
		string temp = " Inventory:";
		foreach (Item item in this.inventory) {
			temp += "\n - " + item.ItemName;
		}
		return temp;
 	}

	/// <summary>
	/// Removes the item.
	/// </summary>
	/// <param name="item">Item.</param>
	public void RemoveItem(Item item)
	{
		// Removes item from the inventory
		this.inventory.Remove (item);
	}
		
}
