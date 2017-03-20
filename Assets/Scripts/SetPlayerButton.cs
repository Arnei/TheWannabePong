using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class SetPlayerButton : MonoBehaviour {

	public void buttonPrompt(string button)
	{
		StartCoroutine (buttonPromptEnumerable(button));
	}
		
	IEnumerator buttonPromptEnumerable(string button)
	{
		while (Input.anyKey == false || Input.GetMouseButton(0))
			yield return null;
		Debug.Log ("Any Key pressed");

		KeyCode curKey = getCurrentlyPressedKey ();
		if (curKey == KeyCode.None)
			yield break;
		Debug.Log ("Key is: " + curKey.ToString ());

		switch(button)
		{
		case "P1Up":
			InputDefinitions.ChangeP1Up (curKey);
			break;
		case "P1Down":
			InputDefinitions.ChangeP1Down (curKey);
			break;
		case "P2Up":
			InputDefinitions.ChangeP2Up (curKey);
			break;
		case "P2Down":
			InputDefinitions.ChangeP2Down (curKey);
			break;
		}

	}

	private KeyCode getCurrentlyPressedKey()
	{		
		Debug.Log ("Input String: " + Input.inputString);
		if (Regex.IsMatch (Input.inputString, @"^[\p{L}\p{N}]+$"))
			return (KeyCode)System.Enum.Parse (typeof(KeyCode), Input.inputString.ToUpper());
		else
			return KeyCode.None;
	}
}
