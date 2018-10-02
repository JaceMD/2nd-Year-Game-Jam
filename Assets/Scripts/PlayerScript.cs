using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {


	public Text search;
	public Text hide;
	GameObject closestBed;
	public float speed;
	bool hiding;
	bool searching;
	bool delay;
	public GameObject nunAI;

	// Use this for initialization
	void Start () {
		search.enabled = false;
		hide.enabled = false;
		delay = false;
	}
	
	// Update is called once per frame
	void Update () {

		playerMovement ();

		closestBed = findClosestBed ();

		if (closestBed != null) {
			search.enabled = true;
			hide.enabled = true;							//enables UI text when the player is close to a bed
			playerControl ();

		} else {
			search.enabled = false;
			hide.enabled = false;
		}

		if (hiding) {
			print ("Hiding");
		}

		if (searching) {
			print ("Searching");
		}

	}

	void playerMovement()									//function that allows the player to move based on the speed input in the inspector
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed);
		}
	}

	void playerControl()																	//function that allows the player to hide under beds and to search for stuff
	{
		if (Input.GetKey (KeyCode.E) && !hiding) {											//Button pressed to let player search.
			searching = true;
			nunAI.GetComponent<NunScript> ().investigateNoise (transform.position);
		} else {
			searching = false;
		}

		if (Input.GetKeyDown (KeyCode.Q) && !searching && !hiding && !delay) {				//Button pressed to let player hide
			hiding = true;
			delay = true;
			StartCoroutine (WaitABit());

		}

		if (Input.GetKeyDown (KeyCode.Q) && !searching && hiding && !delay) {
			hiding = false;
			delay = true;
			StartCoroutine (WaitABit());
		}
	}


	GameObject findClosestBed() 						//function that finds the closest bed and returns that object to the update
	{
		GameObject cBed = null;
		GameObject[] bedList = GameObject.FindGameObjectsWithTag ("Bed");

		for (int loop = 0; loop < bedList.Length; loop++) {
			if (cBed == null) {
				cBed = bedList [loop];
			}

			if (Vector3.Distance(transform.position, bedList[loop].transform.position) <= Vector3.Distance(transform.position, cBed.transform.position)) {
				cBed = bedList[loop];
			}
		}

		if (cBed != null) {														//returns null if the bed is out of the range of player
			if (Mathf.Abs (transform.position.x - cBed.transform.position.x) > 4.8f || Mathf.Abs (transform.position.z - cBed.transform.position.z) > 5.7f) {
				cBed = null;
			}
		}

		return cBed;
	}
		
	IEnumerator WaitABit()
	{
		yield return new WaitForSeconds (0.3f);
		delay = false;
	}
}
