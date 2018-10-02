using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NunScript : MonoBehaviour {

	[SerializeField]

	NavMeshAgent navAgent;

	Vector3 destination;

	bool suspects;							//Set to true if heard a noise and hasn't found anything
	bool heardNoise;						//Set to true if initial noise is heard

	// Use this for initialization
	void Start () {
		navAgent = this.GetComponent<NavMeshAgent> (); 
		heardNoise = false;
	}
	
	// Update is called once per frame
	void Update () {
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

	void followGeneralPath()
	{
		
		
	}
		
	void lookAtBeds()
	{
		GameObject[] bedList = GameObject.FindGameObjectsWithTag ("Bed");
	}

	public void investigateNoise(Vector3 noiseSource)
	{
		destination = noiseSource;


		navAgent.SetDestination (destination);
		heardNoise = true;

		if (Vector3.Distance (transform.position, noiseSource) < 5.6f) {
			heardNoise = false;
			print ("Looked at");
		}

	}


}
