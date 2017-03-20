using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GraphicPanelInit : MonoBehaviour {

	public Dropdown resDD;
	public Dropdown fullscreenDD;

	// Use this for initialization
	void Start () {
		// Init resolution dropdown
		initFullscreenDropdown (fullscreenDD, Screen.fullScreen);
		initResolutionDropdown (resDD, Screen.fullScreen);

	}

	/**
	// Get Dropdown Child Element
	Dropdown getDropDown(string theName)
	{
		Dropdown[] dropdowns = GetComponentsInChildren<Dropdown> ();
		foreach(Dropdown comp in dropdowns )
		{
			if (comp.name == theName)
				return comp;
		}
		throw new UnityException ("Could not find dropdown");
	}
	*/

	public void initFullscreenDropdown(Dropdown fullscreenDD, bool fullscreen)
	{
		for(int i=0; i < fullscreenDD.options.Count; i++)
		{
			Debug.Log ("GPINIT List: " + fullscreenDD.options [i].text);
			if (fullscreen && (fullscreenDD.options [i].text == "Fullscreen"))
			{
				fullscreenDD.value = i;
				Debug.Log ("GPINIT: Fullscreen");
			}
			if (!fullscreen && (fullscreenDD.options [i].text == "Windowed")) 
			{
				fullscreenDD.value = i;
				Debug.Log ("GPINIT: Windowed");
			}
		}
	}

	public void initResolutionDropdown(Dropdown resDD, bool fullscreen)
	{
		// Clear Dropdown List
		resDD.ClearOptions ();

		// Variables
		Resolution[] resolutions = Screen.resolutions;		// Original resolutions
		resolutions = resolutions.Distinct().ToArray ();	// Remove all multiples
		List<string> resList = new List<string> ();			// Strings for the dropdown menu
		int startValue = 0;									// StartValue for the Menu

		// Get all resolutions 
		for(int i=0; i < resolutions.Count(); i++)
		{
			resList.Add (resolutions[i].width + "x" + resolutions[i].height);
			// Get current resolution
			if (resolutions[i].width == Screen.width &&			// Width and height of the player window. .currentresolution would instead give the resolution of the screen, regardless of window size
				resolutions[i].height == Screen.height)
			{
				startValue = i;
				Debug.Log ("Current REs: " + Screen.currentResolution);
			}
		}
			
		// Add all resolutions to Dropdown
		resDD.AddOptions (resList);
		resDD.value = startValue;
		resDD.RefreshShownValue ();

		// Add listener to change resolution
		resDD.onValueChanged.AddListener(delegate 
			{ 
				Screen.SetResolution(resolutions[resDD.value].width, resolutions[resDD.value].height, fullscreen); 
				PlayerPrefs.SetInt("resWidth", resolutions[resDD.value].width);
				PlayerPrefs.SetInt("resHeight", resolutions[resDD.value].height);
				PlayerPrefs.SetInt("resFullscreen", fullscreen == true ? 1 : 0);
				//ResolutionAdapter.AdaptCameraToResolution(); 		Does not work here
			});
	}



	public void toggleLeFullscreen(int menuItemIndex)
	{
		if(menuItemIndex == 0)
		{
			Screen.fullScreen = false;
			initResolutionDropdown (resDD, false);
			print ("Windowed");
		}
		else if (menuItemIndex == 1)
		{
			Screen.fullScreen = true;
			initResolutionDropdown (resDD, true);
			print ("Fullscreen");
		}
	}


}
