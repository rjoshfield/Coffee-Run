using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	private List<IngUI> recipe;
	public int recipeSize = 3;

	private TimerManager timer;

	public GameObject i1;
	public GameObject i2;
	public GameObject i3;

	public GameObject[] uiThings;

	public void Start ()
	{
		newRecipe ();
		timer = GameObject.Find ("GameManager").GetComponent<TimerManager> ();
		uiThings = new GameObject[] {i1, i2, i3};
		Debug.Log ("Recipe: " + recipe [0].EType + " " + recipe [1].EType + " " + recipe [2].EType);
	}

	public void Update(){
		if (recipe.Count < 1) newRecipe();
	}

	public void newRecipe()
	{
		recipe = new List<IngUI> ();
		for (int i = 0; i < recipeSize; i++) {
			IngUI ing = new IngUI ();
			recipe.Add(ing);
			uiThings [i].GetComponent<SpriteRenderer> ().sprite = ing.GetComponent<SpriteRenderer> ().sprite;
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

				if (type == recipe[i].EType)
				{
					recipe[i].Acquired = true;
					break;
					// Add points 
				} 
				else
				{
					if (i == recipe.Count -1)
					{
						newRecipe ();
						break;
					}					
					continue;
				}
			}
		}
	}

}
