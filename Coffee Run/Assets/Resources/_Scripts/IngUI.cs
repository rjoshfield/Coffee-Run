using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngUI : Ingredient
{
	private bool _acquired = false;

	public bool Acquired
	{
		get { return _acquired; }
		set { _acquired = value; }
	}

	public void Randomize(){
		_eType = (IType)Random.Range (0, iLength);
		sr = GetComponent<SpriteRenderer> ();
		sprites = Resources.LoadAll<Sprite> ("_Sprites/Ingredients");

		foreach (Sprite s in sprites) {
			if (s.name == EType.ToString ()) {
				sr.sprite = s;
			}
		}
	}
}

