using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour {

	public void reloadthisScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
