using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private CharacterController player;

    public float speed;
    public float gravity;
    public float jumpForce = 3f;
    //public float buttonDelayTimer = 1.0f;
    public Rigidbody playerRB;

    public enum playerState {Default, Jumping, Diving, Sliding}
    public playerState currentState;

    public GameObject[] playerStateObjs;
    public GameObject currentStateObj;

    public float holdStateTime = .6f;

    //private bool playerInput = false;// 
    /*
    [SerializeField]
    private bool upKey = false;
    [SerializeField]
    private bool downKey = false;
    [SerializeField]
    private bool middleHeightPassed = false;
    [SerializeField]
    private bool groundHeightPassed = false;
    [SerializeField]
    private bool slidingHeightPassed = false;
    */
    [SerializeField]
    private bool grounded = false;
    [SerializeField]
    private const float maxHeight = 3f;
    [SerializeField]
    private const float groundHeight = -3;
    [SerializeField]
    private const float slideHeight =
        //groundHeight + (groundHeight + maxHeight);// 
        -4f;
    [SerializeField]
    private float minHeight =
        //groundHeight - maxHeight / 2;
        -5f;
    //public Vector2 velocity;

    public GameObject gameOverPanel;
    public Text gameOverText;

    public Recipe rec;
    public Ingredient ing;

    void Start()
    {
        rec = GameObject.Find("Main Camera").GetComponent<Recipe>();

        playerRB = GetComponent<Rigidbody>();

        if (playerStateObjs.Length == 0)
        {
            playerStateObjs = new GameObject[transform.childCount];

            int i = 0;
            foreach (Transform child in transform)
            {
                playerStateObjs[i] = child.gameObject;
                i++;
            }
        }

        currentStateObj = playerStateObjs[0];
    }

    //just for reference
    //transform.position += transform.up jumpSpeed Time.deltaTime

    /*
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
*/

    void FixedUpdate()
    {
        //buttonPress();
        stateCheck();
        playerMovement();

    }

    void stateCheck()
    {
        /*
        // MidJump State Check
        if (upKey == true && middleHeightPassed == false && playerRB.transform.position.y > groundHeight + maxHeight)
        {
            upKey = false;
            downKey = false;
            middleHeightPassed = true;
            playerRB.velocity = Vector2.zero;
        }
        else if (downKey == true && middleHeightPassed == true && playerRB.transform.position.y < maxHeight + groundHeight)
        {
            upKey = false;
            downKey = false;
            middleHeightPassed = false;
            playerRB.velocity = Vector2.zero;
        }
        // GroundHeight State Check
        // Has an extra arguement because player starts in this state
        if (upKey == true && groundHeightPassed == false && (playerRB.transform.position.y > groundHeight || playerRB.transform.position.y == groundHeight))
        {
            upKey = false;
            downKey = false;
            groundHeightPassed = true;
            playerRB.velocity = Vector2.zero;
        }
        else if (downKey == true && groundHeightPassed == true && playerRB.transform.position.y < groundHeight)
        {
            upKey = false;
            downKey = false;
            groundHeightPassed = false;
            playerRB.velocity = Vector2.zero;
        }

        // Sliding State Check
        if (downKey == true && grounded == true && slidingHeightPassed == false && playerRB.transform.position.y < slideHeight)
        {
            ChangeState(4);
            upKey = false;
            downKey = false;
            slidingHeightPassed = true;
            playerRB.velocity = Vector2.zero;
        }
        else if (upKey == true && grounded == true && slidingHeightPassed == true && playerRB.transform.position.y >= groundHeight)
        {
            slidingHeightPassed = false;
            ChangeState(1);

        }*/
        // Grounded boolean State Check

        if (playerRB.transform.position.y <= groundHeight && playerRB.transform.position.y >= minHeight)
        {
            grounded = true;
            if (currentState == playerState.Jumping)
            {
                StartCoroutine(ChangeState(playerState.Default, .2f));
            }
            //Debug.Log("Speed: " + playerRB.velocity);
        }
        else
        {
            grounded = false;
        }
    }
    
    /*
    void buttonPress()
    {
        //if(playerInput == false){
        if (Input.GetKey(KeyCode.UpArrow))
        {
            upKey = true;
            downKey = false;
            //StartCoroutine (buttonDelay());
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            upKey = false;
            downKey = true;
            //StartCoroutine (buttonDelay());
        }
        //}
    }
    */

    void playerMovement()
    {
        //print(playerRB.velocity);
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && currentState != playerState.Jumping)
        {
            //==========================================================================
            //these are the old method used
            //playerRB.MovePosition( playerRB.position + velocity * Time.fixedDeltaTime );
            //basically the same thing as the last almost
            //this.gameObject.transform.Translate(0, jumpForce,0,Space.World);
            //==========================================================================
            playerRB.useGravity = true;

            playerRB.velocity = (new Vector3(0, jumpForce));
            //transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
            StartCoroutine(ChangeState(playerState.Jumping, 0));
            //Debug.Log("Speed: " + playerRB.velocity);
        }

        else if ((Input.GetKeyDown(KeyCode.DownArrow)) == true && grounded && currentState != playerState.Sliding)
        {
            playerRB.useGravity = false;

            StartCoroutine(HoldState(playerState.Sliding));

            //Debug.Log("Speed: " + playerRB.velocity);
        }

        else if ((Input.GetKeyDown(KeyCode.RightArrow)) == true && grounded && currentState != playerState.Diving)
        {
            playerRB.useGravity = false;

            StartCoroutine(HoldState(playerState.Diving));

            //Debug.Log("Speed: " + playerRB.velocity);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) == true && playerRB.transform.position.y > minHeight)
        {
            playerRB.velocity = Vector2.down * jumpForce;
            //Debug.Log("Speed: " + playerRB.velocity);
        }
        
        /*
        else
        {
            //Resets player input checks
            upKey = false;
            downKey = false;
            players.velocity = Vector2.zero;
        }
        */
    }

    IEnumerator ChangeState(playerState stateToChangeTo, float changeTime)
    {
        yield return new WaitForSeconds(changeTime);
        int stateNumber = (int)stateToChangeTo;
        currentState = stateToChangeTo;

        currentStateObj.SetActive(false);
        playerStateObjs[stateNumber].SetActive(true);
        currentStateObj = playerStateObjs[stateNumber];

        print("current state:" + currentState);


        //currentStateObj.SetActive(false);
        //currentState = playerState.Default;

        //currentStateObj = playerStateObjs[0];
        //currentStateObj.SetActive(true);
    }

    IEnumerator HoldState(playerState stateToChangeTo)
    {
        //print("doing");

        currentState = stateToChangeTo;
        int stateNumber = (int) stateToChangeTo;
        //ChangeState(stateNumber);
        currentStateObj.SetActive(false);
        playerStateObjs[stateNumber].SetActive(true);
        currentStateObj = playerStateObjs[stateNumber];

        print("current state:" + currentState);

        yield return new WaitForSeconds(holdStateTime);

        currentStateObj.SetActive(false);
        currentState = playerState.Default;

        currentStateObj = playerStateObjs[0];
        currentStateObj.SetActive(true);
    }

    void OnColliderEnter(Collider other)
    {
		if (other.tag == "Obstacle")
        {
			gameOverText.text = "Game Over";
		}
	}

    public void OnTriggerEnter(Collider other)
    {
        //ALL PLAYER HIT DETECTION MOVED TO PLAYER STATE OBJECTS
        //PLEASE SEE "PLAYERHITBOX" SCRIPT, ATTACHED TO "State_" OBJECTS!
        //Direct hit detection events from "PlayerHitbox" to your manager for recipe and cup tracking
    }
}
