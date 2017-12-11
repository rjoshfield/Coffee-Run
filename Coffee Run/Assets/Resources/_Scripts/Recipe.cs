using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour {

	private List<GameObject> recipe;
	public int recipeSize = 3;

	private TimerManager timer;

	public GameObject i1;
	public GameObject i2;
	public GameObject i3;

	public ScoreManager sc;
    public CoffeeManager cm;

    public Sprite checkSprite;


    public void Start ()
	{
		recipe = new List<GameObject> {i1, i2, i3};
		timer = GameObject.Find ("GameManager").GetComponent<TimerManager> ();
		sc = GameObject.Find ("Score").GetComponent<ScoreManager> ();
        cm = GameObject.Find("Main Camera").GetComponent<CoffeeManager>();

    }

    public void Update(){
        if (recipe[0].GetComponent<IngUI>().Acquired == true && recipe[1].GetComponent<IngUI>().Acquired == true && recipe[2].GetComponent<IngUI>().Acquired == true)
        {
            newRecipe();
            cm.AddCoffee();
            sc.AddPoints(10);
        }
	}

	public void newRecipe()
	{

        foreach (GameObject ing in recipe)
        {
            ing.GetComponent<IngUI>().Randomize();
            ing.GetComponent<IngUI>().Acquired = false;
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

				if (type.Equals(recipe[i].GetComponent<IngUI>().EType) && !recipe[i].GetComponent<IngUI>().Acquired)
				{
					recipe[i].GetComponent<IngUI>().Acquired = true;
					sc.AddPoints (5);
                    recipe[i].GetComponent<Image>().sprite = checkSprite;
                    //recipe[i].GetComponent<Image>().sprite = Resources.Load ("_Sprites/check") as Sprite;
					break;
				} 
				else
				{
                    if (i == recipe.Count - 1)
                        newRecipe();
					continue;
				}
			}
		}
	}

}
