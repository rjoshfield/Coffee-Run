using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
	public float groundHorizontalLength;
	public BoxCollider2D groundCollider;

	public GameObject[] backgrounds;
	public GameObject randomBackground;
	public GameObject currentBackground;
	public GameObject oldBackground;
	public GameObject tempBackground;


	void Start(){
		tempBackground = Instantiate(currentBackground, Vector2.zero, Quaternion.identity);
		groundCollider = tempBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;

	}

	void Update () {
		//Check if
		if (tempBackground.transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		}
			
	}

	private void RepositionBackground()
	{	
		//Destroy last background
		//oldBackground = currentBackground;
		//Destroy (oldBackground);

		//Generate random background from a list of backgrounds
		randomBackground = backgrounds [Random.Range (0, backgrounds.Length)];

		//Set the current background to the new randombackground
		currentBackground = randomBackground;

		//Update Colliders & etc.
		UpdateBackgroundReference ();

		//currentBackground.transform.position = (Vector2)transform.position + groundOffset;
		tempBackground = Instantiate(currentBackground, (Vector2)currentBackground.transform.position, Quaternion.identity);
	}

	private void UpdateBackgroundReference()
	{

		//Update collider and length
		groundCollider = currentBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;

		//Offset (From MIGOS!) to Instantiate BG
		//Vector2 groundOffset = new Vector2 (groundHorizontalLength, 0);

	}
}
