using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	private List<GameObject> recipe;
	public int recipeSize = 3;

	private TimerManager timer;

	public GameObject i1;
	public GameObject i2;
	public GameObject i3;

	public void Start ()
	{
		recipe = new List<GameObject> {i1, i2, i3};
		timer = GameObject.Find ("GameManager").GetComponent<TimerManager> ();
		foreach (GameObject ing in recipe)
			Debug.Log (ing.GetComponent<IngUI> ().EType.ToString ());
	}

	public void Update(){
		if (recipe [0].GetComponent<IngUI> ().Acquired == true && recipe [1].GetComponent<IngUI> ().Acquired == true && recipe [2].GetComponent<IngUI> ().Acquired == true)
			newRecipe ();
	}

	public void newRecipe()
	{
		foreach (GameObject ing in recipe) {
			ing.GetComponent<IngUI> ().Randomize ();
		}
	}

	public void Got(IType type)
	{
		if (type == IType.Energy) 
		{
			timer.AddTime ();
		} 
		else 
		{
			for (int i=0; i < recipe.Count; i++)
			{

				if (type.Equals(recipe[i].GetComponent<IngUI>().EType))
				{
					recipe[i].GetComponent<IngUI>().Acquired = true;
					break;
					// Add points 
				} 
				else
				{					
					continue;
				}
			}
		}
	}

}
