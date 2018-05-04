using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	PieceController pieceCtrl;
	private ButtonController buttonLeft;
	private ButtonController buttonRight;
	private ButtonController buttonUp;
	private ButtonController buttonDown;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		pieceCtrl = GameObject.Find ("ChessPlayerSprite").GetComponent<PieceController> ();
		buttonLeft = GameObject.Find ("ButtonLeft").GetComponent<ButtonController> ();
		buttonRight = GameObject.Find ("ButtonRight").GetComponent<ButtonController> ();
		buttonUp = GameObject.Find ("ButtonUp").GetComponent<ButtonController> ();
		buttonDown = GameObject.Find ("ButtonDown").GetComponent<ButtonController> ();
	}
		
	/// <summary>
	/// Update this instance. Checks if any movement button is pressed and gives string according to the direction
	/// </summary>
	void Update ()
	{
		if (buttonRight.GetButtonPressed () || Input.GetKey("d")){
			pieceCtrl.Move ("right");
		}
		if (buttonLeft.GetButtonPressed () || Input.GetKey("a")) {
			pieceCtrl.Move ("left");
		}
		if (buttonUp.GetButtonPressed () || Input.GetKey("w")) {
			pieceCtrl.Move ("up");
		}
		if (buttonDown.GetButtonPressed () || Input.GetKey("s")) {
			pieceCtrl.Move ("down");
		}

	}


}
