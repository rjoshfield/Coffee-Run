using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

	private List<IngUI> recipe;
	public int recipeSize = 3;

	public Recipe()
	{
		newRecipe ();
	}

	public void newRecipe()
	{
		recipe = new List<IngUI> ();
		for (int i = 0; i < recipeSize; i++) {
			IngUI ing = new IngUI ();
			recipe.Add(ing);
		}
	}

	public void Got(IType type)
	{
		if (type == IType.Energy) 
		{
			//call Egnergy increase
		} 
		else 
		{
			foreach (var ing in recipe)
			{
				if (type == ing.EType)
				{
					ing.Acquired = true;
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
