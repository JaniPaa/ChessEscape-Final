using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

	// The objects used to display and manage text in Unity

	public GameObject textBox;
	public Text dialogueText;
	public TextAsset textFile;
	public TextAsset textFile2;
	public TextAsset textFile3;
	private string[] textLines;
	private int currentLine;
	private int lastLine;
	private int scene;
	private bool nextScene;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start ()
	{
		// Used for story scenes
		// Assigns text lines to array and counts the number of lines in file
		textLines = (textFile.text.Split ('\n'));
		lastLine = textLines.Length - 1;
		nextScene = true;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		// Assigns text lines from array to the text box
		// If the dialogue is for a story scene, loads the next scene after going through the text lines
		dialogueText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Space))
		{
			currentLine++;
		}

		if (currentLine > lastLine && (nextScene))
		{
			scene = SceneManager.GetActiveScene().buildIndex;
			scene++;
			SceneManager.LoadScene(scene);
		}
	}

}