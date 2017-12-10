 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IType
{
	Milk,
	Sweetener,
	Flavor,
	Energy,
	Special
}

public class Ingredient : MonoBehaviour {

	private int iLength;
	private IType _eType;
	private SpriteRenderer sr;
	private Sprite[] sprites;

	public void Awake()
	{
		iLength = System.Enum.GetNames(typeof(IType)).Length;
		_eType = (IType)Random.Range(0, iLength);
		sr = GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>("_Sprites/Ingredients");

		foreach (Sprite s in sprites)
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
