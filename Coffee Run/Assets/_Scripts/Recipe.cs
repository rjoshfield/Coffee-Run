using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	private List<IngUI> recipe;
	public int recipeSize;

	void Start(){

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void newRecipe()
	{
		recipe = new List<IngUI> ();
		for (int i = 0; i < recipeSize; i++) {
			IngUI ing = new IngUI ();
			recipe.Add(ing);
		}
	}
}
