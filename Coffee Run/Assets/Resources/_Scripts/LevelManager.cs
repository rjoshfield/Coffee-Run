﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public float groundHorizontalLength;
	public BoxCollider2D groundCollider;

	public GameObject[] backgrounds;
	public GameObject oldBackground;
	public GameObject tempBackground;

	// For makeItem()
	public GameObject itemPrefab;
	public List<GameObject>items;


	void Start(){
		backgrounds = Resources.LoadAll<GameObject>("_BackgroundPrefabs");
        //tempBackground = Instantiate (backgrounds [Random.Range (0, backgrounds.Length)], Vector2.zero, Quaternion.identity);
        tempBackground = Instantiate (tempBackground, Vector2.zero, Quaternion.identity);

        MakeItem();

		groundCollider = tempBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
		items = new List<GameObject> (); // Initialize list for makeItem()
	}

	void Update () {
		//Check if
		if (tempBackground.transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		} 
	}

	private void RepositionBackground()
	{	
		//Set the current background to the new randombackground
		tempBackground = backgrounds[Random.Range(0,backgrounds.Length)];

		//Update Colliders & etc.
		UpdateBackgroundReference ();

		tempBackground = Instantiate(tempBackground, new Vector2 (tempBackground.transform.position.x + 5, tempBackground.transform.position.y), Quaternion.identity);
		MakeItem ();
	}

	private void UpdateBackgroundReference()
	{
		//Update collider and length
		groundCollider = tempBackground.GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x;
	}

	private void MakeItem()
	{
		GameObject[] eItems;
		GameObject iGO;

		eItems = GameObject.FindGameObjectsWithTag("Item");

		foreach(GameObject iItem in eItems)
		{
			items.Add(iItem);
		}

		foreach (GameObject item in items) {
			iGO = Instantiate (itemPrefab, item.transform.position, Quaternion.identity);
			Destroy (item);
			iGO.transform.parent = tempBackground.transform;
		}

		items.Clear ();
	}



	public void RestartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(LevelManager.);

    }
}
