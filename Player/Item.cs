using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	private string itemName;


	/// <summary>
	/// Gets or sets the name of the item.
	/// </summary>
	/// <value>The name of the item.</value>
	public string ItemName 
	{

		get 
		{
			return itemName;
		}

		set 
		{
			this.itemName = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Item"/> class.
	/// </summary>
	/// <param name="itemName">Item name.</param>
	public Item(string itemName)
	{
		ItemName = itemName;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Item"/> class.
	/// </summary>
	public Item()
	{
		ItemName = "Not found";
	}
}
