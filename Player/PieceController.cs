using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PieceController : MonoBehaviour{

	public float pieceSpeed = 1f;
	private bool onCollision = false;
	List<Item> door = new List<Item>();
	Inventory inventory;
	Item keyItem;
	Item crowbarItem;
	Text textPlayerInventory;
	Text textNextLevel;
	public Text textGameOver;
	RoomManager roomer;
	public static bool openDoor = false;
	public static string currentLevel = "Cell";
	private Animator anime;

	/// <summary>
	/// Checks the door open.
	/// </summary>
	/// <returns><c>true</c>, if door open was checked, <c>false</c> otherwise.</returns>
	public bool checkDoorOpen()
	{
		// Checks if the door has been opened
		openDoor = true;
		return openDoor;
	}

	/// <summary>
	/// Resets the door.
	/// </summary>
	/// <returns><c>true</c>, if door was reset, <c>false</c> otherwise.</returns>
	public bool resetDoor()
	{
		// If the player dies, the door is closed again
		openDoor = false;
		return openDoor;
	}
		
	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnCollisionEnter2D (Collision2D other)
	{
		// If player comes in contact with an item tagged as "key", it will be added to his inventory
		// and the item will dissapear from the map.
		if (other.gameObject.CompareTag ("Key")) {
			other.gameObject.SetActive (false);
			inventory.AddItem (keyItem);
			textPlayerInventory.text = inventory.GetInventoryList ();
			door.Add (keyItem);
		}
		// If player hits and crowbar object it is added to his inventory and removed from the map
		if (other.gameObject.CompareTag ("Crowbar")) {
			other.gameObject.SetActive (false);
			inventory.AddItem (crowbarItem);
			textPlayerInventory.text = inventory.GetInventoryList ();
			door.Add (crowbarItem);
		}
		// If player comes in contact with cell door with cell key in his inventory, the door will open and inventory will be refreshed and the enemies wake up
		if(other.gameObject.CompareTag("CellDoor") && door.Contains(keyItem)){
			other.gameObject.SetActive (false);
			door.Remove (keyItem);
			inventory.RemoveItem (keyItem);
			textPlayerInventory.text = inventory.GetInventoryList ();
			checkDoorOpen ();

		}
		// If player touches door in the wall, Story1 dialog loads
		if(other.gameObject.CompareTag("Level")){
			resetDoor ();
			roomer.getCurrentLevel ("Hallway");
			textNextLevel.text = currentLevel;
			roomer.loadRoom ("Story1");

		}
		// If player is hit by enemy, it calls gameover method and the room restarts
		if (other.gameObject.CompareTag ("Enemy")) {
			textGameOver.text = endGame ();
			roomer.resetLevel ();
			resetDoor ();

		}
		// Loads Story2 dialog when player hits door with crowbar in his inventory
		if (other.gameObject.CompareTag ("Level3") && door.Contains(crowbarItem)) {
			roomer.getCurrentLevel ("Kitchen");
			textNextLevel.text = currentLevel;
			roomer.loadRoom ("Story2");
			resetDoor ();
		}

		// Opens door when player collides with it crowbar in his inventory. Removes the crowbar from the inventory
		if (other.gameObject.CompareTag ("CrowbarDoor") && door.Contains (crowbarItem)) {
			other.gameObject.SetActive (false);
			door.Remove(crowbarItem);
			inventory.RemoveItem(crowbarItem);
			textPlayerInventory.text = inventory.GetInventoryList();
		}

		// When player hits tile "level4" Story3 dialog is loaded
		if (other.gameObject.CompareTag ("Level4")) {
			roomer.loadRoom ("Story3");
		}
		// When player hits Start object it loads StoryStart dialog
		if (other.gameObject.CompareTag ("Start")) {
			roomer.loadRoom ("StoryStart");
		}
	}
		
	/// <summary>
	/// Move the specified dir.
	/// </summary>
	/// <param name="dir">Dir.</param>
	public void Move (string dir)
	{
		if (!onCollision) {
			
			if (dir == "right") {
				transform.Translate (pieceSpeed * 0.05f, 0, 0);
			}
			if (dir == "left") {
				transform.Translate (pieceSpeed * -0.05f, 0, 0);
			}
			if (dir == "up") {
				transform.Translate (pieceSpeed * 0, 0.05f, 0);
			}
			if (dir == "down") {
				transform.Translate (pieceSpeed * 0, -0.05f, 0);
			}
		}
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		roomer = GetComponent<RoomManager> ();
		textPlayerInventory = GameObject.Find ("TextPlayerInventory").GetComponent<Text> ();
		textPlayerInventory.text = (" Inventory: " + "\n - Empty -");
		inventory = new Inventory();
		keyItem = new Item ("Cell Key");
		crowbarItem = new Item ("Crowbar");
		textGameOver = GameObject.Find ("TextGameOver").GetComponent<Text> ();
		textNextLevel = GameObject.Find ("TextLevel").GetComponent<Text> ();
		textNextLevel.text = currentLevel;
	}

	/// <summary>
	/// Game over method
	/// </summary>
	/// <returns>The game.</returns>
	public string endGame()
	{
		// Displays "Game Over!" message
		string end = "You Died!";
		return end;
	}
		
}