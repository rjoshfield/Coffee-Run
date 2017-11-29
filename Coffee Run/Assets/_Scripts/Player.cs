using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	void Start()
	{
		
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y++;
			this.transform.position = position * speed;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y--;
			this.transform.position = position * speed;
		}
	}
}
