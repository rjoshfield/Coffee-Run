using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	private Rigidbody2D rb;
	public float scrollingSpeed;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 ((scrollingSpeed * -1), 0);
	}
	
	// Update is called once per frame
	void Update (){
	}

}
