using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeManager : MonoBehaviour {

    public GameObject[] coffees;
    public int numCoffees;
    public ScoreManager sc;

	// Use this for initialization
	void Start () {
        sc = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            CashIn();
    }

    public void AddCoffee()
    {
        if (numCoffees < coffees.Length)
            numCoffees++;
        coffees[numCoffees - 1].SetActive(true);
    }

    public void ResetCoffees()
    {
        numCoffees = 0;

        foreach (GameObject coffee in coffees)
            coffee.SetActive(false);
    }

    public void CashIn()
    {
        sc.AddPoints(numCoffees * (5* numCoffees));
        ResetCoffees();
    }


}
