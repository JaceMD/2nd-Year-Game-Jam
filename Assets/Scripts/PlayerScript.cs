using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	Vector3 originalSize;
	public Text search;
	public Text hide;
	GameObject closestBed;
	public float speed;
	bool hiding;
	bool searching;
	bool delay;
	public GameObject nunAI;
	public GameObject searchProg;
	bool item_1_Found;
	bool item_2_Found;
	bool item_3_Found;
	bool item_4_Found;

	// Use this for initialization
	void Start () {
		search.enabled = false;
		hide.enabled = false;
		delay = false;
		hiding = true;

		originalSize = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {


		if (!hiding && !searching) {
			playerMovement ();
		}

		closestBed = findClosestBed ();

			if (closestBed != null && closestBed.GetComponent<BedScript> ().playerBed) {     //enables UI text when player is close to own bed
			if (!hiding) {
				hide.text = "Q to get in";
			} else {
				hide.text = "Left or Right to get out";
			}
				hide.enabled = true;
				playerBedControl ();
			} else if (closestBed != null && !closestBed.GetComponent<BedScript> ().playerBed) {
			if (!hiding) {
				hide.text = "Q to hide";
				search.enabled = true;
			} else {
				hide.text = "Left or Right to get out";
				search.enabled = false;
			}
				hide.enabled = true;							//enables UI text when the player is close to a bed
				playerControl ();
			} else {
				search.enabled = false;
				hide.enabled = false;
			}

		if (item_1_Found && item_2_Found && item_3_Found && item_4_Found) {
			print ("Game Ends");
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

			if (closestBed.GetComponent<BedScript> ().anyItems ()) {
				searchProg.GetComponent<SearchProgress> ().search ();
			} else {
				//What happens when there is no item in the place where the player is searching
			}

		} else {
			searching = false;
			searchProg.GetComponent<SearchProgress> ().stopSearch ();
		}

		if (Input.GetKeyDown (KeyCode.Q) && !searching && !hiding && !delay) {				//Button pressed to let player hide
			hiding = true;
			hideUnder ();
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) && hiding) {								//Buttons pressed to let player come out from hiding
			hiding = false;
			transform.position = closestBed.transform.position - new Vector3 (3f, 0, 0);
			transform.localScale = originalSize;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && hiding) {
			hiding = false;
			transform.position = closestBed.transform.position + new Vector3 (3f, 0, 0);
			transform.localScale = originalSize;
		}
	}

	void playerBedControl()
	{
		if (Input.GetKeyDown (KeyCode.Q) && !searching && !hiding && !delay) {				//Button pressed to let player get in own bed
			hiding = true;
			closestBed.GetComponent<BedScript> ().getInBed ();
			transform.position = closestBed.transform.position + new Vector3 (0, 3f, 0);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow) && hiding) {								// Buttons pressed to let player get out of bed
			hiding = false;
			closestBed.GetComponent<BedScript> ().getOutBed ();
			transform.position = closestBed.transform.position - new Vector3 (3f, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && hiding) {
			hiding = false;
			closestBed.GetComponent<BedScript> ().getOutBed ();
			transform.position = closestBed.transform.position + new Vector3 (3f, 0, 0);
		}
	}


	GameObject findClosestBed() 															//function that finds the closest bed and returns that object to the update
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
		
	public void playerBegin(Vector3 playerBed)
	{
		hiding = true;
		transform.position = playerBed + new Vector3 (0, 3f, 0); 
		if (closestBed != null) {
			closestBed.GetComponent<BedScript> ().getInBed ();
		}
	}

	public void objectFound()
	{
		if (closestBed.GetComponent<BedScript> ().getItem() ==  1) {
			item_1_Found = true;
			print ("Item Found");
		}

		if (closestBed.GetComponent<BedScript> ().getItem() == 2) {
			item_2_Found = true;
			print ("Item Found");
		}

		if (closestBed.GetComponent<BedScript> ().getItem() == 3) {
			item_3_Found = true;
			print ("Item Found");
		}

		if (closestBed.GetComponent<BedScript> ().getItem() == 4) {
			item_4_Found = true;
			print ("Item Found");
		}
	}

	void hideUnder()
	{
		transform.localScale = new Vector3(1.6f, 1f, transform.localScale.z);
		transform.position = closestBed.transform.position + new Vector3 (0f,-1f,0f);
	}
		
	IEnumerator WaitABit()
	{
		yield return new WaitForSeconds (0.3f);
		delay = false;
	}
}
