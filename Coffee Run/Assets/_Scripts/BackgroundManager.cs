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

	// For makeItem()
	public GameObject itemPrefab;
	public List<GameObject>items;


	void Start(){
		tempBackground = Instantiate(currentBackground, Vector2.zero, Quaternion.identity);
		groundCollider = tempBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
		items = new List<GameObject> (); // Initialize list for makeItem()

	}

	void Update () {
		Debug.Log (tempBackground.transform.position);
		//Check if
		if (tempBackground.transform.position.x < -groundHorizontalLength) {
			Debug.Log ("TRUE");
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
		Debug.Log ("groundCollider is now " + currentBackground.name);
		groundHorizontalLength = groundCollider.size.x;

		//Offset (From MIGOS!) to Instantiate BG
		//Vector2 groundOffset = new Vector2 (groundHorizontalLength, 0);

	}

	public void makeItem()
	{
		GameObject[] eItems;

		eItems = GameObject.FindGameObjectsWithTag("Item");

		foreach(GameObject iItem in eItems)
		{
			items.Add(iItem);
		}

		foreach (GameObject item in items) {
			Instantiate (itemPrefab, item.transform.position, item.transform.rotation);
			Destroy (item);
			items.Remove (item);
		}
	}
}
