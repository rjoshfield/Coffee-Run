using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour {
	private float groundHorizontalLength;
	private BoxCollider2D groundCollider;

	public GameObject[] backgrounds;
	public GameObject randomBackground;
	public GameObject currentBackground;
	public GameObject oldBackground;

	void Start(){
		currentBackground = Instantiate(currentBackground, Vector2.zero, Quaternion.identity);

		groundCollider = currentBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;

		Debug.Log (groundHorizontalLength);
	}

	void Update () {
		//Check if
		if (currentBackground.transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
			Debug.Log ("Passed");
		}
	}

	private void RepositionBackground()
	{	
		//Destroy last background
		oldBackground = currentBackground;
		//Destroy (oldBackground);

		//Generate random background from a list of backgrounds
		randomBackground = backgrounds [Random.Range (0, backgrounds.Length)];

		//Set the current background to the new randombackground
		currentBackground = randomBackground;

		//Update collider and length
		groundCollider = currentBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;


		//Offset (From MIGOS!) to Instantiate BG
		Vector2 groundOffset = new Vector2 (groundHorizontalLength, 0);

		//currentBackground.transform.position = (Vector2)transform.position + groundOffset;
		Instantiate(currentBackground, (Vector2)currentBackground.transform.position, Quaternion.identity);
	}
}
