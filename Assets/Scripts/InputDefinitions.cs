using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDefinitions : MonoBehaviour {

	public static InputDefinitions inputDefinitions;	//Singleton

	public static KeyCode P1Up;
	public static KeyCode P1Down;
	public static KeyCode P2Up;
	public static KeyCode P2Down;

	void Awake()
	{
		if(inputDefinitions == null)
		{
			DontDestroyOnLoad (gameObject);	// Persistent between scenes
			inputDefinitions = this;

			// Additional initialisation
			P1Up = StringToKeyCode (PlayerPrefs.GetString ("P1Up", "Q"));
			P1Down = StringToKeyCode (PlayerPrefs.GetString ("P1Down", "A"));
			P2Up = StringToKeyCode (PlayerPrefs.GetString ("P2Up", "O"));
			P2Down = StringToKeyCode (PlayerPrefs.GetString ("P2Down", "L"));
		}
		else if(inputDefinitions != this)
		{
			Destroy (gameObject);
		}

	}

	private KeyCode StringToKeyCode(string input)
	{
		return (KeyCode)System.Enum.Parse (typeof(KeyCode), input);
	}

	public static void ChangeP1Up(KeyCode newKey)
	{
		P1Up = newKey;
		PlayerPrefs.SetString ("P1Up", newKey.ToString ());
		Debug.Log ("Key changed to: " + newKey.ToString ());
	}
	public static void ChangeP1Down(KeyCode newKey)
	{
		P1Down = newKey;
		PlayerPrefs.SetString ("P1Down", newKey.ToString ());
	}
	public static void ChangeP2Up(KeyCode newKey)
	{
		P2Up = newKey;
		PlayerPrefs.SetString ("P2Up", newKey.ToString ());
	}
	public static void ChangeP2Down(KeyCode newKey)
	{
		P2Down = newKey;
		PlayerPrefs.SetString ("P2Down", newKey.ToString ());
	}
}
