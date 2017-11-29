using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private CharacterController player;

	public float speed;
	public float gravity;
	public float jumpForce;

	void Start()
	{
		
	}

	//just for reference
	//transform.position += transform.up jumpSpeed Time.deltaTime
		
	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector2 position = this.transform.position;
			position.y++;
			this.transform.position = position * speed;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector2 position = this.transform.position;
			position.y--;
			this.transform.position = position * speed;
		}
	}
}
