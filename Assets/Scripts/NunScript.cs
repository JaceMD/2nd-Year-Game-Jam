using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NunScript : MonoBehaviour {

	[SerializeField]

	NavMeshAgent navAgent;

	Vector3 destination;

	bool suspects;							//Set to true if heard a noise and hasn't found anything.
	bool heardNoise;						//Set to true if initial noise is heard.
	bool bedLooked;							//Set to true if a bed has been assessed so next one can be assessed.

	public Transform pos1;
	public Transform pos2;
	public Transform pos3;
	public Transform pos4;

	public GameObject bedWatch;

	GameObject closestBed;

	bool atPos1;
	bool atPos2;
	bool atPos3;
	bool atPos4;

	// Use this for initialization
	void Start () {
		navAgent = this.GetComponent<NavMeshAgent> (); 
		heardNoise = false;
		destination = pos1.position;
		bedLooked = true;
	}
	
	// Update is called once per frame
	void Update () {

		closestBed = findClosestBed ();

		if (heardNoise) {
			investigateNoise (destination);
		}

		if (!heardNoise && suspects) {
			lookAtBeds ();
		}

		if (!heardNoise && !suspects) {
			followGeneralPath ();
		}
	}

	void followGeneralPath()										//Function that makes the nun follow the general path around the room
	{
		if (Vector3.Distance (transform.position, pos1.position) < 2f) {
			destination = pos2.position;
		}

		if (Vector3.Distance (transform.position, pos2.position) < 2f) {
			destination = pos3.position;
		}

		if (Vector3.Distance (transform.position, pos3.position) < 2f) {
			destination = pos4.position;
		}

		if (Vector3.Distance (transform.position, pos4.position) < 2f) {
			destination = pos1.position;
		}

		navAgent.SetDestination (destination);
		
	}
		
	void lookAtBeds()												//Function that makes the nun move to positions from where she can check each bed to see if its empty
	{
		navAgent.SetDestination (bedWatch.transform.position);

		if(Vector3.Distance(transform.position, bedWatch.transform.position) < 4f && bedLooked)
		{
			bedLooked = false;
			StartCoroutine (bedGlance());
		}
	}

	public void investigateNoise(Vector3 noiseSource)				//Function that makes the nun move towards the last place where a source of noise was detected
	{
		destination = noiseSource;


		navAgent.SetDestination (destination);
		heardNoise = true;

		if (Vector3.Distance (transform.position, noiseSource) < 5.6f) {
			heardNoise = false;
			suspects = true;
			print ("Looked at");
			StartCoroutine (WaitABit());
		}
	}

	public void endSuspicion()										//Function that makes the nun stop looking at each bed
	{
		suspects = false;
		bedLooked = true;
	}

	IEnumerator WaitABit()											//Wait used after looking at the source of noise
	{
		yield return new WaitForSeconds (1f);
		destination = pos1.position;
	}

	IEnumerator bedGlance()											//Wait used for everytime the nun stops to check each bed
	{
		yield return new WaitForSeconds (1f);
		if (closestBed != null) {
			if (closestBed.GetComponent<BedScript> ().bedFilled) {
				print ("Nun sees filled bed");
			} else {
				print ("NUN FINDS EMPTY BED");
			}
		}
		bedWatch.GetComponent<BedWatchScript> ().nextBed ();
		bedLooked = true;
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

}
