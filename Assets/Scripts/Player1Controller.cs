using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

	public float speed;
	public int invert;
	public int invertExtend;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	// Before any physics calculations
	void FixedUpdate()
	{
		if(Input.GetKey (InputDefinitions.P1Up))
			rb2d.velocity = new Vector2 (0, 1) * speed * invert;
		else if(Input.GetKey (InputDefinitions.P1Down))
			rb2d.velocity = new Vector2 (0, -1) * speed * invert;		
		else
			rb2d.velocity = new Vector2 (0, 0) * speed * invert;		
		//float moveVertical = Input.GetAxisRaw ("P1_Vertical");
		//rb2d.velocity = new Vector2 (0, moveVertical) * speed * invert;
	}

}
