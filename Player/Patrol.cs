using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	public float enemySpeed;

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		//Setting default speed and direction
		transform.Translate (new Vector3(enemySpeed, 0, 0) * Time.deltaTime);
	}

	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="block">Block.</param>
	void OnCollisionEnter2D(Collision2D block)
	{
		// If Enemy hits a wall with a tag "PatrolTile", it's x-direction is reversed
		if(block.gameObject.CompareTag("PatrolTile")){
			enemySpeed = enemySpeed * -1;

		}
	}
}
