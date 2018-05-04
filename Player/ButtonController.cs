using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	private bool buttonPressed;

	/// <summary>
	/// Raises the pointer down event.
	/// </summary>
	/// <param name="e">E.</param>
	public void OnPointerDown (PointerEventData e)
	{
		// If movement button is being pressed
		buttonPressed = true;
	}

	/// <summary>
	/// Raises the pointer up event.
	/// </summary>
	/// <param name="e">E.</param>
	public void OnPointerUp (PointerEventData e)
	{
		// If movement button are not being pressed
		buttonPressed = false;
	}

	/// <summary>
	/// Gets the button pressed.
	/// </summary>
	/// <returns><c>true</c>, if button pressed was gotten, <c>false</c> otherwise.</returns>
	public bool GetButtonPressed ()
	{
		// returns if movement button is pressed
		return buttonPressed;
	}
}
