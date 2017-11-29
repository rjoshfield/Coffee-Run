using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	private float groundHorizontalLength;
	private BoxCollider2D groundCollider;
	public GameObject[] backgrounds;

	void Start() {
		
		backgrounds = Resources.LoadAll ("BackgroundPrefabs", typeof(GameObject));

		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
		Debug.Log (groundHorizontalLength);


	}

	void Update () {
		if (transform.position.x < -groundHorizontalLength) {

			RepositionBackground ();
			Debug.Log ("Passed");
		}
	}

	private void RepositionBackground()
	{
		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
