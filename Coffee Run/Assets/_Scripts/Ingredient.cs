using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IType
{
	Milk,
	Sweetener,
	Flavor
}

public class Ingredient : MonoBehaviour {



	protected int iLength;
	protected IType _eType;
	protected SpriteRenderer sr;
	protected Sprite[] sprites;

	void Awake()
	{
		iLength = System.Enum.GetNames(typeof(IType)).Length;
		_eType = (IType)Random.Range(0, iLength);
		sr = GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>("Sprites/Ingredients");

		foreach (var s in sprites)
		{
			if (s.name == EType.ToString())
			{
				sr.sprite = s;
			}
		}
	}

	public IType EType
	{
		get { return _eType; }
		protected set { _eType = value; }
	}
}
