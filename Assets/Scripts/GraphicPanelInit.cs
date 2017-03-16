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
			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				startValue = i;
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
