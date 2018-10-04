using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : MonoBehaviour {

	public bool item_1;
	public bool item_2;
	public bool item_3;
	public bool item_4;
	public bool playerBed;
	public bool bedFilled;

	bool start;


	// Use this for initialization
	void Start () {
		start = false;
		item_1 = false;
		item_2 = false;
		item_3 = false;
		item_4 = false;
		playerBed = false;
		bedFilled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!start && !playerBed) {
			start = true;
		}

		if (!start && playerBed) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ().playerBegin (transform.position);
			if (bedFilled == true) {
				start = true;
			}
		}
	}

	public void setItem_1()
	{
		item_1 = true;
		print ("Item 1 placed here:" + this.gameObject.name);
	}

	public void setItem_2()
	{
		item_2 = true;
		print ("Item 2 placed here:" + this.gameObject.name);
	}

	public void setItem_3()
	{
		item_3 = true;
		print ("Item 3 placed here:" + this.gameObject.name);
	}

	public void setItem_4()
	{
		item_4 = true;
		print ("Item 4 placed here:" + this.gameObject.name);
	}

	public bool anyItems()
	{
		if (item_1 || item_2 || item_3 || item_4) {
			return true;
		}
		return false;
	}

	public void setPlayerBed()
	{
		playerBed = true;
		print ("PlayerBed placed here:" + this.gameObject.name);
	}

	public void getInBed ()
	{
		bedFilled = true;
		print ("In Bed");
	}

	public void getOutBed()
	{
		bedFilled = false;
		print("Got out of bed");
	}

	public int getItem()
	{
		if (item_1) {
			item_1 = false;
			print ("Item Found");
			return 1;
		} else if (item_2) {
			item_2 = false;
			print ("Item Found");
			return 2;
		} else if (item_3) {
			item_3 = false;
			print ("Item Found");
			return 3;
		} else if (item_4) {
			item_4 = false;
			print ("Item Found");
			return 4;
		}
		return 0;
	}
}
