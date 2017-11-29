using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : IngBase
{
	private bool _acquired = false;

	public bool Acquired
	{
		get { return _acquired; }
		set { _acquired = value; }
	}
}

