using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngUI : MonoBehaviour
{
	
	private int iLength;
	private IType _eType;
	private SpriteRenderer sr;
	private Sprite[] sprites;

	private bool _acquired = false;
	Image m_Image;

	public bool Acquired
	{
		get { return _acquired; }
		set { _acquired = value; }
	}

	public void Awake ()
	{
		m_Image = GetComponent<Image> ();
		iLength = System.Enum.GetNames(typeof(IType)).Length;
		Randomize ();
	}

	public void Randomize(){
		_eType = (IType)Random.Range (0, iLength);
		if (EType == IType.Energy)
			Randomize ();
		sprites = Resources.LoadAll<Sprite> ("_Sprites/Ingredients");

		foreach (Sprite s in sprites) {
			if (s.name == EType.ToString ()) {
				m_Image.sprite = s;
			}
		}
	}

	public IType EType
	{
		get { return _eType; }
		protected set { _eType = value; }
	}
}

