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
}

