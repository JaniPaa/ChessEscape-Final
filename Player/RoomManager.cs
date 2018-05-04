using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public class RoomManager : MonoBehaviour{

	/// <summary>
	/// Loads the room.
	/// </summary>
	/// <param name="room">Room.</param>
	public void loadRoom(string room)
	{
		//loads a scene, what it receives as a parameter
		SceneManager.LoadScene (room);
	}

	/// <summary>
	/// Gets the current level.
	/// </summary>
	/// <returns>The current level.</returns>
	/// <param name="lvl">Lvl.</param>
	public string getCurrentLevel(string lvl)
	{
		//Displays current level player is on
		PieceController.currentLevel = lvl;

		return lvl;
	}

	/// <summary>
	/// Resets the level.
	/// </summary>
	public void resetLevel()
	{
		// Resets the level
		Application.LoadLevel (Application.loadedLevel);
	}


}
