using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
        if (player == null)
            player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ing")
        {
            print("Hit Ingredient!");
            player.ing = other.gameObject.GetComponent<Ingredient>();
            player.rec.Got(player.ing.EType);
            Destroy(other.gameObject);
        }
        if (other.tag == "Obstacle")
        {
            player.gameOverPanel.SetActive(true);
            player.gameOverText.text = "Game Over";
        }
    }
}
