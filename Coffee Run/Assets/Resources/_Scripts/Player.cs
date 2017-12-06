using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private CharacterController player;

	public float speed;
	public float gravity;
	public float jumpForce;

	public Text gameOverText;

	void Start()
	{

	}

	//just for reference
	//transform.position += transform.up jumpSpeed Time.deltaTime
		
	void Update() {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Vector2 position = this.transform.position;
			position.y += 2;
			this.transform.position = position * speed;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Vector2 position = this.transform.position;
			position.y -= 2;
			this.transform.position = position * speed;
		}

	}

	void OnColliderEnter(Collider other){
		if (other.tag == "Obstacle") {
			gameOverText.text = "Game Over";
		}
	}
}
