﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAdapter : MonoBehaviour {

	public static ResolutionAdapter resolutionAdapter;	//Singleton


	void Awake()
	{
		if(resolutionAdapter == null)
		{
			DontDestroyOnLoad (gameObject);	// Persistent between scenes
			resolutionAdapter = this;

			// Additional initialisation
		}
		else if(resolutionAdapter != this)
		{
			Destroy (gameObject);
		}

	}


	// Use this for initialization
	void Start () {
		AdaptCameraToResolution ();
	}

	// Calling this in the Listener of the resolution dd menu doesn't work
	void Update(){
		AdaptCameraToResolution ();
	}
	
	public static void AdaptCameraToResolution()
	{
		// set the desired aspect ratio (the values in this example are
		// hard-coded for 16:9, but you could make them into public
		// variables instead so you can set them at design time)
		float targetaspect = 16.0f / 9.0f;

		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;

		// obtain camera component so we can modify its viewport
		Camera camera = Camera.main;

		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{  
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		}
		else // add pillarbox
		{
			float scalewidth = 1.0f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}

	}
}
